using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Microsoft.AspNetCore.Mvc;

[Controller]
[Route("api/[controller]")]
public class TreeController : ControllerBase
{
    private readonly ITreeRepository _repository;
    public TreeController(ITreeRepository treeRepository)
    {
        _repository = treeRepository;
    }

    [HttpPost("get")]
    public async Task<IActionResult> get_nodes_by_parent_id([FromBody] Tree model)
    {
        var response = await _repository.get_nodes_by_parent_id(model);
        return Ok(response);
    }

    [HttpPost("insert")]
    public async Task<IActionResult> insert_node([FromBody]Tree model)
    {
        var response = await _repository.insert_node(model);
        return Ok(response);
    }

    [HttpPost("udpate")]
    public async Task<IActionResult> update_node([FromBody]Tree model)
    {
        var response = await _repository.update_node(model);
        return Ok(response);
    }
}