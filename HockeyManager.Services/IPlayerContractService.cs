using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface IPlayerContractService
    {
        public Task<bool> CreatePlayerContract(CreatePlayerContractRequest createPlayerContractRequest);

        public Task<bool> UpdatePlayerContract(ChangePlayerContractRequest changePlayerContractRequest);

        public Task<bool> DeletePlayerContract(string contractId);
    }
}