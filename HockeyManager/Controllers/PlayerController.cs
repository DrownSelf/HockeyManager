using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    [Authorize(Roles = "admin,agent")]
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public IActionResult Manager()
        {
            return View(_playerService.Players);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(CreatePlayerRequest createPlayerRequest)
        {
            if(!ModelState.IsValid)
                return View(createPlayerRequest);
            var result = await _playerService.CreatePlayerAsync(createPlayerRequest);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(ChangePlayerRequest changePlayerRequest)
        {
            if (!ModelState.IsValid)
                return View(changePlayerRequest);
            var result = await _playerService.UpdatePlayerAsync(changePlayerRequest);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePlayer(string id)
        {
            var result = await _playerService.DeletePlayerAsync(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}