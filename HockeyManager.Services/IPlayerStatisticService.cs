using HockeyManager.DataLayer;
using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface IPlayerStatisticService
    {
        public IEnumerable<PlayerStatistic> Statistics { get; }

        public Task<bool> CreatePlayerStatisticAsync(CreatePlayerStatisticRequest createPlayerStatisticRequest);

        public Task<bool> ChangePlayerStatisticAsync(ChangePlayerStatisticRequest changePlayerStatisticRequest);

        public Task<bool> DeletePlayerStatisticAsync(string id);
    }
}
