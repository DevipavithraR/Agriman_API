
using AgrimanAPI.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using AgrimanAPI.Application.Ports;

namespace AgrimanAPI.Api.Controllers
{
    [ApiController]
    [Route("api/packing")]
    public class PackingController : ControllerBase
    {
        private readonly IPackingService _service;

        public PackingController(IPackingService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PackingDto packingDto)
        {
            await _service.AddAsync(packingDto);
            return Ok(new { message = "Packing created successfully" });
        }

        [HttpPost("detail")]
        public async Task<IActionResult> CreateDetail([FromBody] PackingDetailDto detailDto)
        {
            await _service.AddDetailAsync(detailDto);
            return Ok(new { message = "Packing detail created successfully" });
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

