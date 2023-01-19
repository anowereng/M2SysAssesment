using System.Net;

namespace M2SysAssesment.Services.ResponseModel
{
    public class ResponseData
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        
    }
}
