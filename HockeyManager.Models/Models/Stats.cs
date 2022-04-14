using Newtonsoft.Json;

namespace HockeyManager.Models
{
    public class Stats
    {
        [JsonProperty("assists")]
        public int Assists { get; set; }

        [JsonProperty("goals")]
        public int Goals { get; set; }

        [JsonProperty("points")]
        public int Points { get; set; }

        [JsonProperty("shotPct")]
        public double ShotPct { get; set; }

        [JsonProperty("hits")]
        public int Hits { get; set; }

        [JsonProperty("timeOnIcePerGame")]
        public string TimeOnIcePerGame { get; set; }
    }
}
