using Newtonsoft.Json;

namespace RRS_Cloud_Service.Models
{
    public class UserData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }
    }
}
