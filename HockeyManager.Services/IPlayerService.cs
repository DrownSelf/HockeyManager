using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface IPlayerService
    {
        public Task<bool> CreatePlayerAsync(CreatePlayerRequest createPlayerRequest);

        public Task<bool> UpdatePlayerAsync(ChangePlayerRequest changePlayerRequest);

        public Task<bool> DeletePlayerAsync(string id);
    }
}
