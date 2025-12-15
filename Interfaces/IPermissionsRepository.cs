using Homeo_Mart.Models;
using static Homeo_Mart.Models.CommonResponse;

namespace Homeo_Mart.Interfaces
{
    public interface IPermissionsRepository
    {
        Task<ApiListResponse<Permission>> get_permissions(Permission model);
        Task<ApiResponse<int>> insert_permissions(Permission model);
        Task<ApiResponse<int>> update_permissions(Permission model);
        Task<ApiResponse<int>> status_update_permissions(Permission model);
    }
}
