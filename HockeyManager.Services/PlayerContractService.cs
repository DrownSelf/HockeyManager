using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;

namespace HockeyManager.Services
{
    public class PlayerContractService : IPlayerContractService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IPlayerContractRepository _playerContractRepository;

        public PlayerContractService(IPlayerRepository playerRepository, IPlayerContractRepository playerContractRepository)
        {
            _playerRepository = playerRepository;
            _playerContractRepository = playerContractRepository;
        }
        
        public async Task<bool> CreatePlayerContract(CreatePlayerContractRequest createPlayerContractRequest)
        {
            var findedPlayer = await _playerRepository.FindByIdAsync(createPlayerContractRequest.PlayerId);
            if (findedPlayer == null)
                return false;

            var newContract = new PlayerContract
            {
                PlayerContractId = Guid.NewGuid().ToString(),
                PlayerId = findedPlayer.PlayerId,
                Player = findedPlayer,
                USDSalary = createPlayerContractRequest.USDSalary,
                DayOfContractConclusion = createPlayerContractRequest.DayOfContractConclusion,
                DayOfConctractEnding = createPlayerContractRequest.DayOfConctractEnding,
                Benefits = createPlayerContractRequest.Benefits,
            };
            
            var result = _playerContractRepository.CreateAsync(newContract);
            if (!result)
                return false;
            await _playerContractRepository.SaveAsync();
            findedPlayer.PlayerContract = newContract;
            await _playerRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeletePlayerContract(string contractId)
        {
            var findedContract = await _playerContractRepository.FindByIdAsync(contractId);
            if (findedContract == null)
                return false;

            var player = await _playerRepository.FindByIdAsync(findedContract.PlayerId);
            if (player == null)
                return false;

            var result = _playerContractRepository.Delete(findedContract);
            await _playerContractRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdatePlayerContract(ChangePlayerContractRequest changePlayerContractRequest)
        {
            var findedContract = await _playerContractRepository.FindByIdAsync(changePlayerContractRequest.ContractId);
            if (findedContract == null)
                return false;

            findedContract.DayOfConctractEnding = changePlayerContractRequest.DayOfConctractEnding;
            findedContract.DayOfContractConclusion = changePlayerContractRequest.DayOfContractConclusion;
            findedContract.USDSalary = changePlayerContractRequest.USDSalary;
            findedContract.Benefits = changePlayerContractRequest.Benefits;
            
            await _playerContractRepository.SaveAsync();
            return true;
        }
    }
}