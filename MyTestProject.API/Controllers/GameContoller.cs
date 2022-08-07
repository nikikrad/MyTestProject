using Microsoft.AspNetCore.Mvc;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Services.Interfaces;

namespace MyTestProject.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameContoller : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameContoller(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Game game)
        {
            try
            {
                if(game == null)
                {
                    return BadRequest();
                }
                await _gameService.Create(game);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}