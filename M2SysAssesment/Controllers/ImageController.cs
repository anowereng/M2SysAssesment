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
                "https://i.picsum.photos/id/1/5000/3333.jpg?hmac=Asv2DU3rA_5D1xSe22xZK47WEAN0wjWeFOhzd13ujW4",
                "https://i.picsum.photos/id/1/5000/3333.jpg?hmac=Asv2DU3rA_5D1xSe22xZK47WEAN0wjWeFOhzd13ujW4",
                "https://i.picsum.photos/id/2/5000/3333.jpg?hmac=_KDkqQVttXw_nM-RyJfLImIbafFrqLsuGO5YuHqD-qQ",
                "https://i.picsum.photos/id/1/5000/3333.jpg?hmac=Asv2DU3rA_5D1xSe22xZK47WEAN0wjWeFOhzd13ujW4"
            };

            await Download(urls);
            return Ok(responseModel);
        }

        private async Task<bool> Download(IEnumerable<string> urls)
        {
            var path = Path.Combine("wwwroot/images");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var client = new HttpClient();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 1 };
            // now let's send HTTP requests to each of these URLs in parallel
            await Parallel.ForEachAsync(urls, options, async (url, cancellationToken) =>
            {
                HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                // Add our custom headers
                requestMessage.Headers.Add("User-Agent", "Other");

                using (var response = await client.SendAsync(requestMessage))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var fileName = $"{Guid.NewGuid().ToString()}.jpg";

                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                            await response.Content.CopyToAsync(fileStream);
                    }

                }
            });

            return true;

            //var urlTasks = urls.Select(async (url, index) =>
            //{
            //    string ext = Path.GetExtension(url);
            //    using (var client = new HttpClient())
            //    {
            //        HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
            //        // Add our custom headers
            //        requestMessage.Headers.Add("User-Agent", "Other");

            //        using (var response = await client.SendAsync(requestMessage))
            //        {
            //            if (!response.IsSuccessStatusCode)
            //                return (url, null);

            //            var fileName = $"{Guid.NewGuid().ToString()}.jpg";

            //            var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);

            //            using (var fileStream = new FileStream(filePath, FileMode.Create))
            //                await response.Content.CopyToAsync(fileStream);

            //            return (url, fileName);
            //        }
            //    };
            //});
            //await Task.WhenAll(urlTasks);

        }

    }
}