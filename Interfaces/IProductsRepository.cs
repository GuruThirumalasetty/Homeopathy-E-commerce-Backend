using Homeo_Mart.Models.Homeo_Mart.Models;
using static Homeo_Mart.Models.CommonResponse;

public interface IProductRepository
{
    Task<ApiResponse<int>> InsertProduct(product model);
    Task<ApiResponse<int>> UpdateProduct(product model);
    Task<ApiResponse<int>> UpdateProductStatus(product model);
    Task<ApiListResponse<product>> GetProducts(product model);
}
