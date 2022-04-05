using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface IEmployeeContractService
    {
        public Task<bool> CreateEmployeeContractAsync(CreateEmployeeContractRequest createContractRequest);

        public Task<bool> DeleteEmployeeContractAsync(string id);

        public Task<bool> UpdateEmployeeContractAsync(ChangeEmployeeContractRequest changeEmployeeContractRequest);
    }
}