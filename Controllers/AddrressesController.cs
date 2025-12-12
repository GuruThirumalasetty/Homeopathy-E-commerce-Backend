using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly IAddressesRepository _repository;

    public AddressesController(IAddressesRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("get")]
    public async Task<IActionResult> GetAddresses([FromBody] Address model)
    {
        var response = await _repository.GetAddressesAsync(model);
        return Ok(response);
    }

    [HttpPost("insert")]
    public async Task<IActionResult> InsertAddress([FromBody] Address model)
    {
        var response = await _repository.InsertAddressesAsync(model);
        return Ok(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> UpdateAddress([FromBody] Address model)
    {
        var response = await _repository.UpdateAddressesAsync(model);
        return Ok(response);
    }

    [HttpPost("change_status")]
    public async Task<IActionResult> StatusUpdateAddress([FromBody] Address model)
    {
        var response = await _repository.StatusUpdateAddressesAsync(model);
        return Ok(response);
    }
}
