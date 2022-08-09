using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTestProject.API.Request.OSController;
using MyTestProject.BLL.Entities;
using MyTestProject.BLL.Services.Interfaces;

namespace MyTestProject.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OSController: ControllerBase
    {
        private readonly IOSService _iOSService;
        private readonly IMapper _mapper;
        public OSController(IOSService oSService, IMapper mapper)
        {
            _iOSService = oSService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await _iOSService.Get();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostOS os)
        {
            try
            {
                if(os == null)
                    return BadRequest();
                var mappedOS = _mapper.Map<OS>(os);
                await _iOSService.Create(mappedOS);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(DeleteOS os)
        {
            try
            {
                if (os == null)
                    return BadRequest(500);
                var mappedOS = _mapper.Map<OS>(os);
                await _iOSService.Delete(mappedOS);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
