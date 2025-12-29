using Agriman.Application.Services;
using AgrimanAPI.Api.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace AgrimanAPI.Api.Controllers
{
    [ApiController]
    [Route("api/transaction-work-details")]
    public class TransactionWorkDetailsController : ControllerBase
    {
        private readonly TransactionWorkDetailService _service;
        public TransactionWorkDetailsController(TransactionWorkDetailService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionWorkDetailRequest request)
        {
            var created = await _service.CreateAsync(request.ToDomain());

            return Ok(TransactionWorkDetailResponse.FromDomain(created));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var domain = await _service.GetByIdAsync(id);
            if (domain == null) return NotFound();
            return Ok(TransactionWorkDetailResponse.FromDomain(domain));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _service.GetAllAsync();
            return Ok(list.Select(TransactionWorkDetailResponse.FromDomain));
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update([FromBody] TransactionWorkDetailUpdateRequest request)
        //{
        //    var success = await _service.UpdateAsync(request.ToDomain());
        //    return success ? Ok() : NotFound();
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
         [FromRoute] int id,
         [FromBody] TransactionWorkDetailUpdateRequest request)
        {
            var domain = request.ToDomain(id);
            var success = await _service.UpdateAsync(domain);
            return success ? Ok() : NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? Ok() : NotFound();
        }
    }
}
