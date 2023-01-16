using M2SysAssesment.RequestModel;
using M2SysAssesment.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http.Headers;

namespace M2SysAssesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        public ImageController()
        {

        }

        [HttpPost("DownloadRequestImages")]
        public async Task<IActionResult> PostAsync([FromBody] RequestDownload requestDownload)
        {
            var responseModel = new ResponseDownload();

          var urls = new List<string>()
            {
                "https://images.unsplash.com/photo-1525923838299-2312b60f6d69"
                //"https://i.picsum.photos/id/1/5000/3333.jpg?hmac=Asv2DU3rA_5D1xSe22xZK47WEAN0wjWeFOhzd13ujW4",
                //"https://i.picsum.photos/id/2/5000/3333.jpg?hmac=_KDkqQVttXw_nM-RyJfLImIbafFrqLsuGO5YuHqD-qQ",
                //"https://i.picsum.photos/id/3/5000/3333.jpg?hmac=_KDkqQVttXw_nM-RyJfLImIbafFrqLsuGO5YuHqD-qQ"
            };

            await Download(urls);
            return Ok(responseModel);
        }

        private async Task Download(IEnumerable<string> urls)
        {
            //Console.WriteLine("Start now");
            var localPath = "";

            var path = Path.Combine("wwwroot/images");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            //var fullFileName = Path.Combine("wwwroot", subCategoryName + "//" + webRootPath, fileName);

            var urlTasks = urls.Select(async (url, index) =>
            {
                string ext = System.IO.Path.GetExtension(url);
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //client.DefaultRequestHeaders.Add("User-Agent", "Other");
                    using (var responseStream = await client.GetStreamAsync(url))
                    {
                        //if (!response.IsSuccessStatusCode)
                        //    return (url, null);
                        //var data = await response.st.ReadAsByteArrayAsync().ConfigureAwait(false);
                        //using var fileStream = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                        //response.CopyTo(fileStream);

                        var fileName = $"{Guid.NewGuid().ToString()}.jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await responseStream.CopyToAsync(fileStream);
                        }

                        return (url, fileName);
                    }
                };
            });
            await Task.WhenAll(urlTasks);
            //Console.WriteLine("Done");
            //return urlTasks.Select(x => x.Result).ToArray();
        }

    }
}