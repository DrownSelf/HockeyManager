using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;

namespace HockeyManager.Services
{
    public class EmployeeContractService : IEmployeeContractService
    {
        private IEmployeeContractRepository _employeeContractRepository;

        public EmployeeContractService(IEmployeeContractRepository employeeContractRepository)
        {
            _employeeContractRepository = employeeContractRepository;
        }

        public async Task<bool> CreateEmployeeContractAsync(CreateEmployeeContractRequest createContractRequest)
        {
            var newEmployeeContract = new EmployeeContract
            {
                USDSalary = createContractRequest.USDSalary,
                DayOfContractConclusion = createContractRequest.DateOfConclusion,
                DayOfConctractEnding = createContractRequest.DateOfEnding
            };
            var result = _employeeContractRepository.CreateAsync(newEmployeeContract);
            if (!result)
                return false;
            await _employeeContractRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateEmployeeContractAsync(ChangeEmployeeContractRequest changeContractRequest)
        {
            var findedEmployeeContract = await _employeeContractRepository.FindByIdAsync(changeContractRequest.EmployeeContractId);
            if (findedEmployeeContract == null)
                return false;
            findedEmployeeContract.USDSalary = changeContractRequest.USDSalary;
            findedEmployeeContract.DayOfContractConclusion = changeContractRequest.dayOfConclusion;
            findedEmployeeContract.DayOfConctractEnding = changeContractRequest.dayOfEnding;
            await _employeeContractRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeContractAsync(string id)
        {
            var findedEmployeeContract = await _employeeContractRepository.FindByIdAsync(id);
            if (findedEmployeeContract == null)
                return false;
            var result = _employeeContractRepository.Delete(findedEmployeeContract);
            if (!result)
                return false;
            await _employeeContractRepository.SaveAsync();
            return true;
        }
    }
}
