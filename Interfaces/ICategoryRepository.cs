using Homeo_Mart.Models;
using static Homeo_Mart.Models.CommonResponse;

namespace Homeo_Mart.Interfaces
{
    public interface ICategoryRepository
    {
        Task<ApiListResponse<Category>> GetCategories();
        Task<ApiResponse<Category>> GetCategoryById(Category category);
        Task<ApiResponse<int>> InsertCategory(Category category);
        Task<ApiResponse<int>> UpdateCategory(Category category);
        Task<ApiResponse<int>> UpdateCategoryStatus(Category category);
    }
}
