using Newtonsoft.Json;

namespace Project2Service.Models
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        //public object Data { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
