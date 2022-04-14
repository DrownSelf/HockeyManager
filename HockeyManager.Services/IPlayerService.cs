using HockeyManager.DataLayer;
using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface IPlayerService
    {
        public IEnumerable<Player> Players { get; }

        public Task<bool> CreatePlayerAsync(CreatePlayerRequest createPlayerRequest);

        public Task<bool> UpdatePlayerAsync(ChangePlayerRequest changePlayerRequest);

        public Task<bool> DeletePlayerAsync(string id);
    }
}
