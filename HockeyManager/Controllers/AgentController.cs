using HockeyManager.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> PlayersForAgent()
            => View(await _agentService.GetPlayersInfo());

        [HttpGet]
        public async Task<IActionResult> GetPlayerStats(string id, string season)
            => View(await _agentService.GetPlayerStats(id, season));
    }
}