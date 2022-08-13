using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MyTestProject.API.Request.PlayerController;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Services.Interfaces;

namespace MyTestProject.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PlayerController:ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;
        public PlayerController(IPlayerService playerService, IMapper mapper, IGameService gameService)
        {
            _playerService = playerService;
            _mapper = mapper;
            _gameService = gameService;
        }
        [HttpGet]
        public async Task<ActionResult<Player>> Get()
        {
            try
            {
                var data = await _playerService.Get();
                return Ok(data);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Create(PostPlayer player)
        {
            try
            {
                if(player == null)
                {
                    return BadRequest();
                }
                var mappedPlayer = _mapper.Map<Player>(player);
                await _playerService.Create(mappedPlayer);
                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddGames([FromBody][BindRequired]PostAddGame postAddGameModel)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var player = await _playerService.GetById(postAddGameModel.PlayerId);
                if (player == null)
                {
                    return Problem(
                        title: "Bad value",
                        detail: "Bad player id value",
                        statusCode: 400
                        );
                }
                if(postAddGameModel.GameAdditionals != null)
                {
                    foreach (var gameAdditional in postAddGameModel.GameAdditionals)
                    {
                        var game = await _gameService.GetById(gameAdditional.Id);
                        if (game != null)
                        {
                            player.Game.Add(game);
                        }
                    }
                   await _playerService.Update(player);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(
                        title: "Some trouble on the server",
                        detail: "Oops! Some trouble on the server",
                        statusCode: 500
                        );
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest(500);
                await _playerService.Delete(await _playerService.GetById(id));
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(PutPlayer player)
        {
            try
            {
                if (player == null)
                    return BadRequest(500);
                var mappedPlayer = _mapper.Map<Player>(player);
                await _playerService.Update(mappedPlayer);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
