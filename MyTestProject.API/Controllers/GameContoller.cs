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

        public GameContoller(IGameService gameService, IMapper mapper)
        {
            _gameService = gameService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Game>>> Get()
        {
            try
            {
                var data = await _gameService.Get();
                return Ok(data);
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
                var mappedGame = _mapper.Map<Game>(game);
                await _gameService.Create(mappedGame);
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
                var mappedGame = _mapper.Map<Game>(game);
                await _gameService.Update(mappedGame);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}