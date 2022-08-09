using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTestProject.API.Request.PCController;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Services.Interfaces;

namespace MyTestProject.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PCController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPCService _pcService;
        public PCController(IMapper mapper, IPCService pcService)
        {
            _mapper = mapper;
            _pcService = pcService;
        }

        [HttpGet]
        public async Task<ActionResult<PC>> Get()
        {
            try
            {
                var data = await _pcService.Get();
                return Ok(data);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostPC pc)
        {
            try
            {
                if (pc == null)
                    return BadRequest();

                var mappedPC = _mapper.Map<PC>(pc);
                await _pcService.Create(mappedPC);
                return Ok();
            }catch(Exception ex)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePC pc)
        {
            try
            {
                if (pc == null)
                    return BadRequest(500);
                var mappedPC = _mapper.Map<PC>(pc);
                await _pcService.Delete(mappedPC);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
