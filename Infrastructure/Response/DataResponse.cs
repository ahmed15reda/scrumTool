using Newtonsoft.Json;

namespace Infrastructure.Response
{
    public class DataResponse<T> : GeneralResponse
    {
        [JsonProperty("data")]
        public T Data { get; set; }
        public DataResponse(T data, string message = "Data Fetched Successfully", bool status = true) : base(message, status)
        {
            Data = data;
        }
    }
}
