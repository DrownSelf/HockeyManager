using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;

namespace HockeyManager.Services
{
    public class PlayerStatisticService : IPlayerStatisticService
    {
        private readonly IPlayerStatisticRepository _playerStatisticRepository;
        private readonly IPlayerRepository _playerRepository;

        public IEnumerable<PlayerStatistic> Statistics { get => _playerStatisticRepository.Entities; }

        public PlayerStatisticService(IPlayerRepository playerRepository, IPlayerStatisticRepository playerStatisticRepository)
        {
            _playerRepository = playerRepository;
            _playerStatisticRepository = playerStatisticRepository;
        }

        public async Task<bool> ChangePlayerStatisticAsync(ChangePlayerStatisticRequest changePlayerStatisticRequest)
        {
            var findedPlayer = await _playerRepository.FindByIdAsync(changePlayerStatisticRequest.PlayerId);
            if (findedPlayer == null)
                return false;

            var findedStats = findedPlayer.PlayerStatistics;
            findedStats.Goals = changePlayerStatisticRequest.Goals;
            findedStats.Assist = changePlayerStatisticRequest.Assist;
            findedStats.Points = findedStats.Goals + findedStats.Assist;
            findedStats.BenefitIndex = changePlayerStatisticRequest.BenefitIndex;
            findedStats.ShootsOnGoals = changePlayerStatisticRequest.ShootsOnGoals;
            findedStats.BodyCheckingPerGame = changePlayerStatisticRequest.BodyCheckingPerGame;

            await _playerStatisticRepository.SaveAsync();
            return true;
        }

        public async Task<bool> CreatePlayerStatisticAsync(CreatePlayerStatisticRequest createPlayerStatisticRequest)
        {
            var findedPlayer = await _playerRepository.FindByIdAsync(createPlayerStatisticRequest.PlayerId);
            if (findedPlayer == null)
                return false;

            var newStats = new PlayerStatistic
            {
                StatsId = Guid.NewGuid().ToString(),
                PlayerId = findedPlayer.PlayerId,
                Player = findedPlayer,
                Goals = createPlayerStatisticRequest.Goals,
                Assist = createPlayerStatisticRequest.Assist,
                ShootsOnGoals = createPlayerStatisticRequest.ShootsOnGoals,
                BenefitIndex = createPlayerStatisticRequest.BenefitIndex,
                BodyCheckingPerGame = createPlayerStatisticRequest.BodyCheckingPerGame
            };
            newStats.Points = newStats.Assist + newStats.Goals;
            var result = _playerStatisticRepository.CreateAsync(newStats);
            if (!result)
                return false;

            await _playerStatisticRepository.SaveAsync();
            findedPlayer.PlayerStatistics = newStats;
            await _playerRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeletePlayerStatisticAsync(string id)
        {
            var findedUser = await _playerRepository.FindByIdAsync(id);
            if (findedUser == null || findedUser.PlayerStatistics == null)
                return false;

            var result = _playerStatisticRepository.Delete(findedUser.PlayerStatistics);
            if (!result)
                return false;

            await _playerStatisticRepository.SaveAsync();
            return true;
        }
    }
}