using M2SysAssesment.RequestModel;
using M2SysAssesment.ResponseModel;

namespace M2SysAssesment.Services
{
    public interface IImageService
    {
        Task<ResponseDownload> Download(RequestDownload requestDownload);
        ResponseData GetImageByName(string imageName);
    }
}
