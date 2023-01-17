using M2SysAssesment.ResponseModel;
using System.Net;

namespace M2SysAssesment.Common.Helper
{
    public static class ResponseHelper
    {
        public static ResponseDownload SuccessDownloadResponse(Dictionary<string, string> data) =>
             new ResponseDownload() { Message = Constants.Message.AddSuccess, UrlAndNames = data, Success = true };
        public static ResponseDownload FailDownloadResponse() =>
           new ResponseDownload() { Message = Constants.Message.ExceptionMessage, UrlAndNames = null, Success = false };
        public static ResponseDownload ValidationExistUrlResponse() =>
         new ResponseDownload() { Message = Constants.Message.UrlExists, UrlAndNames = null, Success = false };
        public static ResponseDownload ValidationEmptyListResponse() =>
        new ResponseDownload() { Message = Constants.Message.ImageListNullOrEmpty, UrlAndNames = null, Success = false };

    }
}
