
using AgrimanAPI.Api.DTOs;
using AgrimanAPI.Application.Ports;
using AgrimanAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgrimanAPI.Api.Controllers
{
    [ApiController]
    [Route("api/packing")]
    public class PackingController : ControllerBase
    {
        private readonly PackingService _service;

        public PackingController(PackingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PackingCreateDto dto)
        {
            var result = await _service.CreateAsync(dto.PackingId, dto.NumberOfUnits);
            return Ok(result);
        }

    }

}

















//using AgrimanAPI.Application.Ports;
//using AgrimanAPI.Infrastructure.Entities;
//using Microsoft.AspNetCore.Mvc;

//namespace AgrimanAPI.Api.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class PackingController : ControllerBase
//    {
//        private readonly IPackingService _service;

//        public PackingController(IPackingService service)
//        {
//            _service = service;
//        }

//        // GET: api/packing
//        [HttpGet]
//        public async Task<IActionResult> GetAll()
//        {
//            var result = await _service.GetAllAsync();
//            return Ok(result);
//        }

//        // POST: api/packing
//        [HttpPost]
//        public async Task<IActionResult> Create([FromBody] Packing packing)
//        {
//            await _service.AddAsync(packing);
//            return Ok("Packing created successfully");
//        }

//        // POST: api/packing/detail
//        [HttpPost("detail")]
//        public async Task<IActionResult> CreateDetail([FromBody] PackingDetail packingDetail)
//        {
//            await _service.AddDetailAsync(packingDetail);
//            return Ok("Packing detail created successfully");
//        }
//    }
//}

