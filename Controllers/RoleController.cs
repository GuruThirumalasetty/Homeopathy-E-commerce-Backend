using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class RoleController : ControllerBase
{
    private readonly IRoleRepository _repository;

    public RoleController(IRoleRepository repository)
    {
        _repository = repository;
    }

    // ------------------------------------------------------------------------
    // GET ROLES
    // ------------------------------------------------------------------------
    [HttpPost("get")]
    public async Task<IActionResult> GetRoles([FromBody] role model)
    {
        var response = await _repository.GetRoles(model);
        return Ok(response);
    }

    // ------------------------------------------------------------------------
    // INSERT ROLE
    // ------------------------------------------------------------------------
    [HttpPost("insert")]
    public async Task<IActionResult> InsertRole([FromBody] role model)
    {
        var response = await _repository.InsertRole(model);
        return Ok(response);
    }

    // ------------------------------------------------------------------------
    // UPDATE ROLE
    // ------------------------------------------------------------------------
    [HttpPost("update")]
    public async Task<IActionResult> UpdateRole([FromBody] role model)
    {
        var response = await _repository.UpdateRole(model);
        return Ok(response);
    }

    // ------------------------------------------------------------------------
    // UPDATE ROLE STATUS
    // ------------------------------------------------------------------------
    [HttpPost("change_status")]
    public async Task<IActionResult> UpdateRoleStatus([FromBody] role model)
    {
        var response = await _repository.UpdateRoleStatus(model);
        return Ok(response);
    }
}
