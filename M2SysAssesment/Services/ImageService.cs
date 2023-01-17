using M2SysAssesment.Common.Helper;
using M2SysAssesment.RequestModel;
using M2SysAssesment.ResponseModel;

namespace M2SysAssesment.Services
{
    public class ImageService : IImageService
    {
        public async Task<ResponseDownload> Download(RequestDownload requestDownload)
        {
            try
            {
                if(requestDownload.ImageUrls.AreAnyDuplicates())
                    return ResponseHelper.ValidationExistUrlResponse();

                if (requestDownload.ImageUrls.IsNullOrEmpty())
                    return ResponseHelper.ValidationEmptyListResponse();

                var path = Constants.DownloadImagePath;

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
                            var fileName = GetImageName;

                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);

                            using (var fileStream = new FileStream(filePath, FileMode.Create))
                            {
                                await response.Content.CopyToAsync(fileStream);
                                urlAndNames.Add(url, fileName);
                            }
                        }

                    }
                });
               
                return ResponseHelper.SuccessDownloadResponse(urlAndNames);
            }
            catch (Exception ex)
            {
                return ResponseHelper.FailDownloadResponse();
            }
        }

        private string GetImageName => $"Pic-{Guid.NewGuid().ToString()}.jpg";
    }
}
