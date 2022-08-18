using Newtonsoft.Json;

namespace Infrastructure.Response
{
    public abstract class GeneralResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }

        public GeneralResponse(string message, bool status)
        {
            Status = status;
            Message = message;
        }
    }
}
