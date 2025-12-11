using Homeo_Mart.Models;
using Homeo_Mart.Models.Homeo_Mart.Models;
using static Homeo_Mart.Models.CommonResponse;

namespace Homeo_Mart.Interfaces
{
    public interface IProductRepository
    {
        Task<ApiResponse<object>> Insert(product model);
        Task<ApiResponse<object>> Update(product model);
        Task<ApiListResponse<product>> Get(product model);
        Task<ApiResponse<object>> StatusUpdate(product model);
    }
}
