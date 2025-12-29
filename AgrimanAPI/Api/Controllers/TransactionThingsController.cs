using AgrimanAPI.Application.Services;
using AgrimanAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using AgrimanAPI.Api.DTOs;


namespace AgrimanAPI.Api.Controllers;

[ApiController]
[Route("api/transaction-things")]
public class TransactionThingsController : ControllerBase
{
    private readonly TransactionThingsService _service;

    public TransactionThingsController(TransactionThingsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Create(TransactionThingsRequest request)
    {
        var created = await _service.CreateAsync(request.ToDomain());
        return Ok(TransactionThingsResponse.FromDomain(created));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var domain = await _service.GetByIdAsync(id);
        return domain == null
            ? NotFound()
            : Ok(TransactionThingsResponse.FromDomain(domain));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok((await _service.GetAllAsync())
            .Select(TransactionThingsResponse.FromDomain));


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    [FromRoute] int id,
    [FromBody] TransactionThingsUpdateRequest request)
    {
        // 🔹 Load existing data
        var existing = await _service.GetByIdAsync(id);
        if (existing == null)
            return NotFound();

        // 🔹 Create immutable domain correctly
        var domain = request.ToDomain(
            id,
            existing.ThingsId,
            existing.ThingsName);

        var result = await _service.UpdateAsync(domain);

        return Ok(result);
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
        => await _service.DeleteAsync(id) ? Ok() : NotFound();
}