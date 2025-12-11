using Dapper;
using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Homeo_Mart.Services;
using System.Net;
using static Homeo_Mart.Models.CommonResponse;

public class CategoryRepository : BaseRepository, ICategoryRepository
{
    public CategoryRepository(IConfiguration configuration) : base(configuration) { }

    // ➤ INSERT
    public async Task<ApiResponse<int>> InsertCategory(Category category)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("action_type", "INSERT");
            parameters.Add("p_id", null);
            parameters.Add("p_name", category.name);
            parameters.Add("p_code", category.code);
            parameters.Add("p_description", category.description);
            parameters.Add("p_status", category.status);
            parameters.Add("p_user", category.created_by);

            var result = await QuerySingleAsync<int>("hm_manage_category", parameters);

            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.OK,
                Message = "Category inserted successfully",
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Insert failed: {ex.Message}",
                Data = 0
            };
        }
    }

    // ➤ UPDATE CATEGORY
    public async Task<ApiResponse<int>> UpdateCategory(Category category)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("action_type", "UPDATE");
            parameters.Add("p_id", category.id);
            parameters.Add("p_name", category.name);
            parameters.Add("p_code", category.code);
            parameters.Add("p_description", category.description);
            parameters.Add("p_status", category.status);
            parameters.Add("p_user", category.updated_by);

            var result = await QuerySingleAsync<int>("hm_manage_category", parameters);

            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.OK,
                Message = "Category updated successfully",
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Update failed: {ex.Message}",
                Data = 0
            };
        }
    }

    // ➤ UPDATE STATUS ONLY
    public async Task<ApiResponse<int>> UpdateCategoryStatus(Category category)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("action_type", "UPDATE_STATUS");
            parameters.Add("p_id", category.id);
            parameters.Add("p_name", null);
            parameters.Add("p_code", null);
            parameters.Add("p_description", null);
            parameters.Add("p_status", category.status);
            parameters.Add("p_user", category.updated_by);

            var result = await QuerySingleAsync<int>("hm_manage_category", parameters);

            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.OK,
                Message = "Category status updated successfully",
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Status update failed: {ex.Message}",
                Data = 0
            };
        }
    }

    // ➤ GET ALL
    public async Task<ApiListResponse<Category>> GetCategories()
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("action_type", "GET");
            parameters.Add("p_id", null);
            parameters.Add("p_name", null);
            parameters.Add("p_code", null);
            parameters.Add("p_description", null);
            parameters.Add("p_status", null);
            parameters.Add("p_user", null);

            var list = await QueryListAsync<Category>("hm_manage_category", parameters);
            bool hasData = list.Any();

            return new ApiListResponse<Category>
            {
                status_code = hasData ? HttpStatusCode.OK : HttpStatusCode.NotFound,
                Message = hasData ? "Categories fetched successfully" : "No categories found",
                Data = list
            };
        }
        catch (Exception ex)
        {
            return new ApiListResponse<Category>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Error fetching categories: {ex.Message}",
                Data = Enumerable.Empty<Category>()
            };
        }
    }

    // ➤ GET BY ID
    public async Task<ApiResponse<Category>> GetCategoryById(Category category)
    {
        try
        {
            var parameters = new DynamicParameters();
            parameters.Add("action_type", "GET");
            parameters.Add("p_id", category.id);
            parameters.Add("p_name", null);
            parameters.Add("p_code", null);
            parameters.Add("p_description", null);
            parameters.Add("p_status", null);
            parameters.Add("p_user", null);

            var list = await QueryListAsync<Category>("hm_manage_category", parameters);
            var result = list.FirstOrDefault();

            return new ApiResponse<Category>
            {
                status_code = result != null ? HttpStatusCode.OK : HttpStatusCode.NotFound,
                Message = result != null ? "Category fetched successfully" : "Category not found",
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<Category>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Error fetching category: {ex.Message}",
                Data = null
            };
        }
    }
}
