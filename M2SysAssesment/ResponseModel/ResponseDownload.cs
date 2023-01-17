namespace M2SysAssesment.ResponseModel
{
    public class ResponseDownload
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public IDictionary<string, string> UrlAndNames { get; set; }
    }
    public class ResponseData
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public object Data { get; set; }
    }
}
