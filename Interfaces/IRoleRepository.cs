using Homeo_Mart.Models;
using static Homeo_Mart.Models.CommonResponse;

public interface IRoleRepository
{
    Task<ApiResponse<int>> InsertRole(role model);
    Task<ApiResponse<int>> UpdateRole(role model);
    Task<ApiResponse<int>> UpdateRoleStatus(role model);
    Task<ApiListResponse<role>> GetRoles(role model);
}