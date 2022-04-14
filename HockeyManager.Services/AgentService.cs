using HockeyManager.APIs;
using HockeyManager.Models;

namespace HockeyManager.Services
{
    public class AgentService : IAgentService
    {
        private readonly NhlApi _nhlApi;

        public AgentService(NhlApi nhlApi)
        {
            _nhlApi = nhlApi;
        }

        public async Task<List<Teams>> GetPlayersInfo()
            => await _nhlApi.GetPlayers();

        public async Task<StatsForAgent> GetPlayerStats(string id, string season)
            => await _nhlApi.GetPlayerStat(id, season);
    }
}