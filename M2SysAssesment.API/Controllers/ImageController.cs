using M2SysAssesment.Services;
using M2SysAssesment.Services.RequestModel;
using M2SysAssesment.Services.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace M2SysAssesment.API.Controllers
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
        [ProducesResponseType(typeof(ResponseDownload), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] RequestDownload requestDownload)
        {
            var response  = await _imageService.Download(requestDownload);

            if(response.Success)
                return Ok(response);  
            else
                return BadRequest(response);
        }
        [HttpGet]
        [ProducesResponseType(typeof(ResponseData), StatusCodes.Status200OK)]
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