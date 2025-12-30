using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgrimanAPI.Api.Controllers
{
    [ApiController]
    [Route("api/master-workname")]
    public class MasterNameController : ControllerBase
    {
        private readonly MasterWorkNameService _service;
        public MasterNameController(MasterWorkNameService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();

            var response = list.Select(x => new WorkResponseDto
            {
                Id = x.Id,
                WorkName = x.WorkName
            });

            return Ok(response);
        }
    }
}
