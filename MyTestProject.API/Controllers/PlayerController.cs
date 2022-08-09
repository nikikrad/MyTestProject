using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IMapper _mapper;
        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService;
            _mapper = mapper;
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
        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePlayer player)
        {
            try
            {
                if (player == null)
                    return BadRequest(500);
                var mappedPlayer = _mapper.Map<Player>(player);
                await _playerService.Delete(mappedPlayer);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
