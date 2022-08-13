using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTestProject.API.Request.GameController;
using MyTestProject.API.Response.GameController;
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

        public GameContoller(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetGame>>> Get(bool includeCountOfPlayers = false)
        {
            try
            {
                var data = await _gameService.Get(includePlayers: includeCountOfPlayers);
                return Ok(_mapper.Map<List<GetGame>>(data));
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostGame game)
        {
            try
            {
                if (game == null)
                {
                    return BadRequest();
                }
                await _gameService.Create(_mapper.Map<Game>(game));
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (id == null)
                    return BadRequest(500);

                await _gameService.Delete(await _gameService.GetById(id));
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(PutGame game)
        {
            try
            {
                if (game == null)
                    return BadRequest(500);
                await _gameService.Update(_mapper.Map<Game>(game));
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetFreeGames()
        {
            try
            {
                return Ok(await _gameService.GetAllFreeGames());
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetGamesForPrice(int price)
        {
            try
            {
                if (price == null)
                    return BadRequest(500);
                return Ok(await _gameService.GetGamesForPrice(price)); 
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}