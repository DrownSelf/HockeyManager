using Newtonsoft.Json;

namespace HockeyManager.Models
{
    public class Person
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullname")]
        public string Fullname { get; set; }
    }
}
