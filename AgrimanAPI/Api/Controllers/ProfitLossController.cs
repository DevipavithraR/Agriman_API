using AgrimanAPI.Application.Services;
using AgrimanAPI.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AgrimanAPI.Api.Controllers
{
    [ApiController]
    [Route("api/profit-loss")]
    public class ProfitLossController : ControllerBase
    {
        private readonly ProfitLossService _service;

        public ProfitLossController(ProfitLossService service)
        {
            _service = service;
        }

        [HttpGet("get")]
        public IActionResult GetInfo() => Ok("ProfitLoss API is running");

        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate([FromBody] ProfitLossRequest request)
        {
            var result = await _service.CalculateAsync(request.WorkId, request.ThingsId, request.PackingId);
            return Ok(result);
        }
    }
}
