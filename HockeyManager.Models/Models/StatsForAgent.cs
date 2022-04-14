using Newtonsoft.Json;

namespace HockeyManager.Models
{
    [JsonObject("stats")]
    public class StatsForAgent
    {
        [JsonProperty("splits")]
        public Splits Splits { get; set; }
    }
}