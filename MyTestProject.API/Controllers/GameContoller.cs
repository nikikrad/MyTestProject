using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTestProject.API.Request.GameController;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Finder;
using MyTestProject.BLL.Services.Interfaces;

namespace MyTestProject.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GameContoller : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        private readonly IGameFinder _finder;

        public GameContoller(IGameService gameService, IMapper mapper,IGameFinder finder)
        {
            _gameService = gameService;
            _mapper = mapper;
            _finder = finder;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = _finder.GetData();
            return Ok(await data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostGame game)
        {
            try
            {
                if(game == null)
                {
                    return BadRequest();
                }
                var mappedGame = _mapper.Map<Game>(game);
                await _gameService.Create(mappedGame);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        
    }
}