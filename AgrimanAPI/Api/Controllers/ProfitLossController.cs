using Microsoft.AspNetCore.Mvc;
using AgrimanAPI.Application.Services;
using AgrimanAPI.Api.DTOs;

namespace AgrimanAPI.Api.Controllers
{
    [ApiController]
    [Route("api/profit-loss")] // base route
    public class ProfitLossController : ControllerBase
    {
        private readonly ProfitLossService _service;

        public ProfitLossController(ProfitLossService service)
        {
            _service = service;
        }

        // GET api/profit-loss
        [HttpGet]
        [Route("get")]
        public IActionResult GetInfo()
        {
            return Ok("ProfitLoss API is running");
        }

        // POST api/profit-loss/calculate
        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate([FromBody] ProfitLossRequest request)
        {
            var result = await _service.CalculateAsync(
                request.WorkId,
                request.ThingsId,
                request.PackingId
            );

            return Ok(result);
        }
    }

}
