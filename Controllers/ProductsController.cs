using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Homeo_Mart.Models.Homeo_Mart.Models;
using Microsoft.AspNetCore.Mvc;
using static Homeo_Mart.Models.CommonResponse;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository repo;

    public ProductController(IProductRepository repo)
    {
        this.repo = repo;
    }

    [HttpPost("insert")]
    public async Task<IActionResult> Insert([FromBody] product model)
    {
        var res = await repo.Insert(model);
        return Ok(res);
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] product model)
    {
        var res = await repo.Update(model);
        return Ok(res);
    }

    [HttpPost("get")]
    public async Task<IActionResult> Get([FromBody] product model)
    {
        var res = await repo.Get(model);
        return Ok(res);
    }

    [HttpPost("status_update")]
    public async Task<IActionResult> StatusUpdate([FromBody] product model)
    {
        var res = await repo.StatusUpdate(model);
        return Ok(res);
    }
}
