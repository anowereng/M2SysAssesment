using M2SysAssesment.ResponseModel;
using System.Net;

namespace M2SysAssesment.Common.Helper
{
    public static class ResponseHelper
    {
        public static ResponseDownload SuccessDownloadResponse(object data) =>
             new ResponseDownload() { Message = Constants.Message.AddSuccess, UrlAndNames = (IDictionary<string, string>)data, Success = true };
        public static ResponseDownload FailDownloadResponse() =>
           new ResponseDownload() { Message = Constants.Message.ExceptionMessage, UrlAndNames = null, Success = false };
        public static ResponseDownload ValidationExistUrlResponse() =>
         new ResponseDownload() { Message = Constants.Message.UrlExists, UrlAndNames = null, Success = false };
        public static ResponseDownload ValidationEmptyListResponse() =>
        new ResponseDownload() { Message = Constants.Message.ImageListNullOrEmpty, UrlAndNames = null, Success = false };
        public static ResponseDownload ValidationMaxDownloadAtOnce() =>
         new ResponseDownload() { Message = Constants.Message.MaxDownloadAtOnce, UrlAndNames = null, Success = false };

        public static ResponseData SuccessGetResponse(object data) =>
             new ResponseData() { Message = Constants.Message.Success, Data = data, Success = true };
        public static ResponseData FailedGetResponse(object data) =>
       new ResponseData() { Message = Constants.Message.ExceptionMessage, Data = data, Success = true };
        public static ResponseData NotFoundFileResponse() =>
        new ResponseData() { Message = Constants.Message.NotFound, Data = null, Success = true };
        public static ResponseDownload UnknownFormat(object data) =>
            new ResponseDownload() { Message = Constants.Message.UnknownFormat, UrlAndNames = (IDictionary<string, string>)data, Success = false };

    }
}
