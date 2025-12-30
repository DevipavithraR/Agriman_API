using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgrimanAPI.Api.Controllers
{
    [ApiController]
    [Route("api/things")]
    public class MasterThingsController : ControllerBase
    {
        
        private readonly MasterThingsService _service;

        public  MasterThingsController(MasterThingsService service)
        {
            _service = service;
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            var response = list.Select(x => new MasterThingsDto
            {
                Id = x.Id,
                ThingsName = x.ThingName,
                
            });

            return Ok(response);
        }
    }
}

