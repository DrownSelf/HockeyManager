using Newtonsoft.Json;

namespace HockeyManager.Models
{
    public class Team
    {
        [JsonProperty("roster")]
        public List<PlayerForAgent> _players { get; set; }
    }
}