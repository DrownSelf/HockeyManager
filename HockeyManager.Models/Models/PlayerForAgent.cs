using HockeyManager.Models;
using Newtonsoft.Json;

namespace HockeyManager
{
    public class PlayerForAgent
    {
        [JsonProperty("person")]
        public Person Person { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        [JsonProperty("jerseyNumber")]
        public string Number { get; set; }
    }
}