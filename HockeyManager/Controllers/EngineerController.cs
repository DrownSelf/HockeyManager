using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    [Authorize(Roles = "admin,engineer")]
    public class EngineerController : Controller
    {
        private readonly IInventoryService _inventoryService;

        public EngineerController(IInventoryService inventoryService)
        {
            this._inventoryService = inventoryService;
        }

        [HttpGet]
        public IActionResult Manager()
        {
            return View(_inventoryService.Inventory);
        }

        [HttpGet]
        public IActionResult AddItem()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> AddItem(CreateInventoryRequest createInventoryRequest)
        {
            if(!ModelState.IsValid)
                return View(createInventoryRequest);
            var result = await _inventoryService.CreateInventory(createInventoryRequest);
            if (result)
                return RedirectToAction("Manager");
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItem(ChangeInventoryRequest changeInventoryRequest)
        {
            if (!ModelState.IsValid)
                return View(changeInventoryRequest);
            var result = await _inventoryService.UpdateInventory(changeInventoryRequest);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteItem(string id, int amount)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _inventoryService.DeleteInventoryAsync(id, amount);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}