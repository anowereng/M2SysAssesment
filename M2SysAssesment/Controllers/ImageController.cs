using M2SysAssesment.RequestModel;
using M2SysAssesment.ResponseModel;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Post([FromBody] RequestDownload requestDownload)
        {
            var responseModel = new ResponseDownload();


            return Ok(responseModel);
        }
    }
}