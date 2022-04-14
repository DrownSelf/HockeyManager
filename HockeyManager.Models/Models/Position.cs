using Newtonsoft.Json;

namespace HockeyManager.Models
{
    public class Position
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
    }
}
