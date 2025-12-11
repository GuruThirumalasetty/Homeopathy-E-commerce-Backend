using Microsoft.AspNetCore.Mvc;
using Homeo_Mart.Models;
using Homeo_Mart.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    // GET ALL CATEGORIES
    [HttpPost("getallcategories")]
    public async Task<IActionResult> GetCategories()
    {
        var response = await _categoryRepository.GetCategories();
        return Ok(response);
    }

    // INSERT CATEGORY
    [HttpPost("insert")]
    public async Task<IActionResult> InsertCategory([FromBody] Category category)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _categoryRepository.InsertCategory(category);
        return Ok(response);
    }

    // UPDATE CATEGORY
    [HttpPost("update")]
    public async Task<IActionResult> UpdateCategory([FromBody] Category category)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _categoryRepository.UpdateCategory(category);
        return Ok(response);
    }

    // UPDATE CATEGORY STATUS
    [HttpPost("updatestatus")]
    public async Task<IActionResult> UpdateCategoryStatus([FromBody] Category category)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var response = await _categoryRepository.UpdateCategoryStatus(category);
        return Ok(response);
    }

    // GET CATEGORY BY ID
    [HttpPost("getbyid")]
    public async Task<IActionResult> GetCategoryById([FromBody] Category category)
    {
        var response = await _categoryRepository.GetCategoryById(category);
        return Ok(response);
    }
}
