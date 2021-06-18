namespace API.Errors
{
    public interface IApiResponse
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string GetDefaultMessageForStatusCode(int statusCode);
    }
}