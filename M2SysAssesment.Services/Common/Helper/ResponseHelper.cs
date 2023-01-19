using M2SysAssesment.Services.ResponseModel;
using System.Net;

namespace M2SysAssesment.Services.Common.Helper
{
    public static class ResponseHelper
    {
        public static ResponseDownload DownloadResponse(string message, IDictionary<string, string> data = null) =>
            new ResponseDownload() { Message = message, UrlAndNames = data, Success = true };
        public static ResponseData Success(string message, object data = null) =>
             new ResponseData() { Message = message, Data = data, Success = true };
        public static ResponseData Error(string message) =>
            new ResponseData() { Message = message, Data = null, Success = false };

    }
}
