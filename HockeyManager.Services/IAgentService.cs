using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface IAgentService
    {
        public Task<List<Teams>> GetPlayersInfo();

        public Task<StatsForAgent> GetPlayerStats(string id, string season);
    }
}
