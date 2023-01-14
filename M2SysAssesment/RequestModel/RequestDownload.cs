namespace M2SysAssesment.RequestModel
{
    public class RequestDownload
    {
        public IEnumerable<string> ImageUrls { get; set; }
        public int MaxDownloadAtOnce { get; set; }
    }
}
