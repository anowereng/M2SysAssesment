using M2SysAssesment.Common.Helper;
using M2SysAssesment.RequestModel;
using M2SysAssesment.ResponseModel;
using M2SysAssesment.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http.Headers;

namespace M2SysAssesment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private IImageService _imageService; 
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("DownloadRequestImages")]
        public async Task<IActionResult> Post([FromBody] RequestDownload requestDownload)
        {
            var response  = await _imageService.Download(requestDownload);

            if(response.Success)
                return Ok(response);  
            else
                return BadRequest(response);
        }
        [HttpGet]
        [Route("get-image-by-name/{image_name}")]
        public IActionResult GetImageByName(string image_name)
        {
            var response = _imageService.GetImageByName(image_name);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

    }
}