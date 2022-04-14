using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    [Authorize(Roles = "admin,agent")]
    public class PlayerContractController : Controller
    {
        private readonly IPlayerContractService _playerContractService;

        public PlayerContractController(IPlayerContractService playerContractService)
        {
            _playerContractService = playerContractService;
        }

        [HttpGet]
        public IActionResult ManageContract()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContract(CreatePlayerContractRequest createPlayerContractRequest)
        {
            if (!ModelState.IsValid)
                return View(createPlayerContractRequest);
            var result = await _playerContractService.CreatePlayerContract(createPlayerContractRequest);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContract(ChangePlayerContractRequest changePlayerContractRequest)
        {
            if (!ModelState.IsValid)
                return View(changePlayerContractRequest);
            var result = await _playerContractService.UpdatePlayerContract(changePlayerContractRequest);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContract(ChangePlayerContractRequest changePlayerContractRequest)
        {
            if (!ModelState.IsValid)
                return View(changePlayerContractRequest);
            var result = await _playerContractService.UpdatePlayerContract(changePlayerContractRequest);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}