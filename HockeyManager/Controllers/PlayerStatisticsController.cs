using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    [Authorize(Roles = "admin,agent")]
    public class PlayerStatisticsController : Controller
    {
        private readonly IPlayerStatisticService _playerStatisticService;

        public PlayerStatisticsController(IPlayerStatisticService playerStatisticService)
        {
            _playerStatisticService = playerStatisticService;
        }

        [HttpGet]
        public IActionResult Manager()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStats(CreatePlayerStatisticRequest createPlayerStatistics)
        {
            if (!ModelState.IsValid)
                return View(createPlayerStatistics);
            var result = await _playerStatisticService.CreatePlayerStatisticAsync(createPlayerStatistics);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStats(ChangePlayerStatisticRequest updateEmployeeStatistics)
        {
            if (!ModelState.IsValid)
                return View(updateEmployeeStatistics);
            var result = await _playerStatisticService.ChangePlayerStatisticAsync(updateEmployeeStatistics);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStats(string id)
        {
            var result = await _playerStatisticService.DeletePlayerStatisticAsync(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}