using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IPermissionsRepository _repository;

    public PermissionsController(IPermissionsRepository permissionsRepository)
    {
        _repository = permissionsRepository;
    }

    [HttpPost("get")]
    public async Task<IActionResult> get_permissions([FromBody] Permission model)
    {
        var response = await _repository.get_permissions(model);
        return Ok(response);
    }

    [HttpPost("insert")]
    public async Task<IActionResult> insert_permissions([FromBody] Permission model)
    {
        var response = await _repository.insert_permissions(model);
        return Ok(response);
    }

    [HttpPost("update")]
    public async Task<IActionResult> update_permissions([FromBody] Permission model)
    {
        var response = await _repository.update_permissions(model);
        return Ok(response);
    }

    [HttpPost("status_update")]
    public async Task<IActionResult> status_update_permissions([FromBody] Permission model)
    {
        var response = await _repository.status_update_permissions(model);
        return Ok(response);
    }
}
