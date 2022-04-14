using Newtonsoft.Json;

namespace HockeyManager.Models
{
    [JsonObject("teams")]
    public class Teams
    {
        [JsonProperty("teams")]
        public Roster[] Team { get; set; }
    }
}