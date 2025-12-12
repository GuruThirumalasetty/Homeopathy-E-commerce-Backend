using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Homeo_Mart.Models.Homeo_Mart.Models;
using Microsoft.AspNetCore.Mvc;
using static Homeo_Mart.Models.CommonResponse;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        _repository = repository;
    }

    // ------------------------------------------------------------------------
    // GET ALL PRODUCTS
    // ------------------------------------------------------------------------
    [HttpPost("get")]
    public async Task<IActionResult> GetProducts([FromBody] product model)
    {
        var response = await _repository.GetProducts(model);
        return Ok(response);
    }

    // ------------------------------------------------------------------------
    // INSERT PRODUCT
    // ------------------------------------------------------------------------
    [HttpPost("insert")]
    public async Task<IActionResult> InsertProduct([FromBody] product model)
    {
        var response = await _repository.InsertProduct(model);
        return Ok(response);
    }

    // ------------------------------------------------------------------------
    // UPDATE PRODUCT
    // ------------------------------------------------------------------------
    [HttpPost("update")]
    public async Task<IActionResult> UpdateProduct([FromBody] product model)
    {
        var response = await _repository.UpdateProduct(model);
        return Ok(response);
    }

    // ------------------------------------------------------------------------
    // UPDATE PRODUCT STATUS
    // ------------------------------------------------------------------------
    [HttpPost("change_status")]
    public async Task<IActionResult> UpdateProductStatus([FromBody] product model)
    {
        var response = await _repository.UpdateProductStatus(model);
        return Ok(response);
    }
}
