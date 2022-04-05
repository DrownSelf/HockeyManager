using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;

namespace HockeyManager.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryService(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public async Task<bool> CreateInventory(CreateInventoryRequest createInventoryRequest)
        {
            var newInventory = new Inventory
            {
                InventoryId = Guid.NewGuid().ToString(),
                USDCost = createInventoryRequest.USDCost,
                Amount = createInventoryRequest.Amount,
                DataOfLastMaintain = createInventoryRequest.DataOfLastMaintain,
                NameOfAccessory = createInventoryRequest.NameOfAccessory,
                TypeOfAccessory = createInventoryRequest.TypeOfAccessory
            };
            var result = _inventoryRepository.CreateAsync(newInventory);
            if(!result)
                return false;
            await _inventoryRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteInventoryAsync(string id, int amount)
        {
            var findedInventory = await _inventoryRepository.FindByIdAsync(id);
            if (findedInventory == null || amount > findedInventory.Amount)
                return false;

            bool flag = true;
            if (amount == findedInventory.Amount)
                flag = _inventoryRepository.Delete(findedInventory);
            else
                findedInventory.Amount = findedInventory.Amount - amount;

            if (!flag)
                return false;
            await _inventoryRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateInventory(ChangeInventoryRequest changeInventoryRequest)
        {
            var findedInventory = await _inventoryRepository.FindByIdAsync(changeInventoryRequest.InventoryId);
            if (findedInventory == null)
                return false;
            findedInventory.Amount = changeInventoryRequest.Amount;
            findedInventory.NameOfAccessory = changeInventoryRequest.NameOfAccessory;
            findedInventory.TypeOfAccessory = changeInventoryRequest.TypeOfAccessory;
            findedInventory.USDCost = changeInventoryRequest.USDCost;
            await _inventoryRepository.SaveAsync();
            return true;
        }
    }
}