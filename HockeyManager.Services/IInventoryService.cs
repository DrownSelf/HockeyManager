using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface IInventoryService
    {
        public Task<bool> CreateInventory(CreateInventoryRequest createInventoryRequest);

        public Task<bool> DeleteInventoryAsync(string id, int amount);

        public Task<bool> UpdateInventory(ChangeInventoryRequest changeInventoryRequest);
    }
}
