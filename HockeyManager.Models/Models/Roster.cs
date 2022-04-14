using Newtonsoft.Json;

namespace HockeyManager.Models
{
    public class Roster
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("roster")]
        public Team Team { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
