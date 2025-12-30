using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgrimanAPI.Api.Controllers
{
    [ApiController]
    [Route("api/packing")]
    public class MasterPackingController : ControllerBase
    {
        private readonly MasterPackingService _service;
        public MasterPackingController(MasterPackingService service)
        {
            _service = service;
        }
        [HttpGet("get-pack")]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();

            var response = list.Select(x => new PackingResponseDto
            {
                Id = x.Id,
                PackingName = x.PackingName,
                Unit = x.Unit,
                UnitAmount = x.UnitAmount
            });

            return Ok(response);
        }
    }
}
