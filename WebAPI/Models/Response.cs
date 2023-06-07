namespace WebAPI.Models
{
    public class Response<T>
    {
        public string ResponseCode { get; set; }
        public T Data { get; set; }

        public Response(string responseCode, T data)
        {
            ResponseCode = responseCode;
            Data = data;
        }
    }
}
