using M2SysAssesment.Common.Helper;
using M2SysAssesment.RequestModel;
using M2SysAssesment.ResponseModel;
using System.IO;
using static M2SysAssesment.Common.Enums.Enums;
using static System.Net.Mime.MediaTypeNames;

namespace M2SysAssesment.Services
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ImageService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<ResponseDownload> Download(RequestDownload requestDownload)
        {
            try
            {
                if (requestDownload.MaxDownloadAtOnce == 0)
                    return ResponseHelper.ValidationMaxDownloadAtOnce();

                if (requestDownload.ImageUrls.AreAnyDuplicates())
                    return ResponseHelper.ValidationExistUrlResponse();

                if (requestDownload.ImageUrls.IsNullOrEmpty())
                    return ResponseHelper.ValidationEmptyListResponse();

                var path = Path.Combine(_webHostEnvironment.WebRootPath, Constants.DownloadImagePath);

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                var urlAndNames = new Dictionary<string, string>();

                var client = new HttpClient();
                var options = new ParallelOptions() { MaxDegreeOfParallelism = requestDownload.MaxDownloadAtOnce };

                await Parallel.ForEachAsync(requestDownload.ImageUrls, options, async (url, cancellationToken) =>
                {
                    HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                    requestMessage.Headers.Add("User-Agent", "Other");

                    using (var response = await client.SendAsync(requestMessage))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            var fileType = GetImageFormat(response.Content.ReadAsByteArrayAsync().Result);
                            if (fileType == ImageFormat.unknown)
                                return;

                            var fileName = GetImageName(fileType);

                            var filePath = Path.Combine(path, fileName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await response.Content.CopyToAsync(fileStream);
                                urlAndNames.Add(url, fileName);
                            }
                        }
                    }
                });

                if(!urlAndNames.Any())
                    return ResponseHelper.FailDownloadResponse();

                return ResponseHelper.SuccessDownloadResponse(urlAndNames);
            }
            catch (Exception ex)
            {
                return ResponseHelper.FailDownloadResponse();
            }
        }

        public ResponseData GetImageByName(string imageName)
        {
            var filepath = Path.Combine(_webHostEnvironment.WebRootPath, Constants.DownloadImagePath, imageName);

            if (!File.Exists(filepath))
                return ResponseHelper.NotFoundFileResponse();

            var result = Base64ImgString(filepath);
            return ResponseHelper.SuccessGetResponse(result);
        }
        private string Base64ImgString(string filepath)
        {
          
            var fileExtension = Path.GetExtension(filepath);
            var contents = File.ReadAllBytes(filepath);
            return $"data:image/{fileExtension};base64,{Convert.ToBase64String(contents)}";
        }
        private ImageFormat GetImageFormat(byte[] bytes)
        {
            var png = new byte[] { 137, 80, 78, 71 };              // PNG                                                                   
            var jpeg = new byte[] { 255, 216, 255, 224 };          // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 };         // jpeg canon

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return ImageFormat.png;

            else if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return ImageFormat.jpeg;

            else if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return ImageFormat.jpeg;

            return  ImageFormat.unknown;
        }
        private string GetImageName(ImageFormat format) => $"Pic-{Guid.NewGuid().ToString()}.{format}";
    }
}
