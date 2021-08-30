using Newtonsoft.Json;
using System;

namespace Project2Service.Models
{
    public class Contact
    {
        [JsonProperty("ID")]
        public int Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("DateAdded")]
        public DateTime DateAdded { get; set; }

        [JsonProperty("DateModified")]
        public DateTime DateModified { get; set; }
    }
}


