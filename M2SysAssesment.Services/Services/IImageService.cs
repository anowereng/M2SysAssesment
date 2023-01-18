using M2SysAssesment.Services.RequestModel;
using M2SysAssesment.Services.ResponseModel;

namespace M2SysAssesment.Services
{
    public interface IImageService
    {
        Task<ResponseDownload> Download(RequestDownload requestDownload);
        ResponseData GetImageByName(string imageName);
    }
}
