using HockeyManager.Models;
using Newtonsoft.Json;

namespace HockeyManager.APIs
{
    public class NhlApi
    {
        private readonly HttpClient _httpClient;

        public NhlApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Teams>> GetPlayers()
        {
            List<Teams> allPlayers = new List<Teams>();
            for (int command = 1; command <= 30; command++)
            {
                string url = string.Format("https://statsapi.web.nhl.com/api/v1/teams/{0}?expand=team.roster", command);
                var json = await _httpClient.GetStringAsync(url);
                Teams playersForAgents = JsonConvert.DeserializeObject<Teams>(json);
                allPlayers.Add(playersForAgents);
            }
            return allPlayers;
        }

        public async Task<StatsForAgent> GetPlayerStat(string id, string season)
        {
            var json = await _httpClient.GetStringAsync("https://statsapi.web.nhl.com/api/v1/people/" + id + "?stats=statsSingleSeason&season=" + season);
            return JsonConvert.DeserializeObject<StatsForAgent>(json);
        }
    }
}