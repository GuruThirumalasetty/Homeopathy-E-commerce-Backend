using Dapper;
using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Homeo_Mart.Services;
using System.Data;
using System.Net;
using System.Text.Json;
using static Homeo_Mart.Models.CommonResponse;

public class RoleRepository : BaseRepository, IRoleRepository
{
    public RoleRepository(IConfiguration configuration) : base(configuration) { }

    // ------------------------------------------------------------------------
    // Build Parameters
    // ------------------------------------------------------------------------
    private DynamicParameters BuildParams(role model, string action)
    {
        var p = new DynamicParameters();

        p.Add("p_action_type", action);
        p.Add("p_id", model.id, DbType.Int32, ParameterDirection.InputOutput);
        p.Add("p_name", model.name);
        p.Add("p_description", model.description);
        p.Add("p_status", model.status);
        p.Add("p_created_by", model.created_by);
        p.Add("p_updated_by", model.updated_by);

        // ⭐ Universal JSON handler (string OR object/list)
        object? permissionsPayload =
    model.permissions_list != null && model.permissions_list.Count > 0
        ? model.permissions_list
        : model.permissions;
        p.Add(
    "p_permissions",
    CommonHelper.NormalizeJson(permissionsPayload)
);

        return p;
    }

    // ------------------------------------------------------------------------
    // INSERT ROLE
    // ------------------------------------------------------------------------
    public async Task<ApiResponse<int>> InsertRole(role model)
    {
        try
        {
            var parameters = BuildParams(model, "insert");

            using var conn = GetConnection();
            await conn.ExecuteAsync(
                "hm_pr_manage_roles",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            int roleId = parameters.Get<int>("p_id");

            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.OK,
                Message = "Role inserted successfully",
                Data = roleId
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

    // ------------------------------------------------------------------------
    // UPDATE ROLE
    // ------------------------------------------------------------------------
    public async Task<ApiResponse<int>> UpdateRole(role model)
    {
        try
        {
            var parameters = BuildParams(model, "update");

            using var conn = GetConnection();
            await conn.ExecuteAsync(
                "hm_pr_manage_roles",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.OK,
                Message = "Role updated successfully",
                Data = model.id
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

    // ------------------------------------------------------------------------
    // UPDATE ROLE STATUS
    // ------------------------------------------------------------------------
    public async Task<ApiResponse<int>> UpdateRoleStatus(role model)
    {
        try
        {
            var parameters = BuildParams(model, "status_update");

            using var conn = GetConnection();
            await conn.ExecuteAsync(
                "hm_pr_manage_roles",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return new ApiResponse<int>
            {
                status_code = HttpStatusCode.OK,
                Message = "Role status updated successfully",
                Data = model.id
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

    // ------------------------------------------------------------------------
    // GET ROLES
    // ------------------------------------------------------------------------
    public async Task<ApiListResponse<role>> GetRoles(role model)
    {
        try
        {
            var parameters = BuildParams(model, "get");

            using var conn = GetConnection();
            var list = (await conn.QueryAsync<role>(
                "hm_pr_manage_roles",
                parameters,
                commandType: CommandType.StoredProcedure
            )).ToList();

            // Deserialize permissions JSON
            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.permissions))
                {
                    try
                    {
                        item.permissions_list =
                            JsonSerializer.Deserialize<List<role_permission>>(item.permissions);
                        item.permissions = null;
                    }
                    catch
                    {
                        item.permissions_list = new List<role_permission>();
                    }
                }
                else
                {
                    item.permissions_list = new List<role_permission>();
                }
            }

            return new ApiListResponse<role>
            {
                status_code = list.Any() ? HttpStatusCode.OK : HttpStatusCode.NotFound,
                Message = list.Any() ? "Roles retrieved successfully" : "No roles found",
                Data = list
            };
        }
        catch (Exception ex)
        {
            return new ApiListResponse<role>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Error fetching roles: {ex.Message}",
                Data = Enumerable.Empty<role>()
            };
        }
    }
}
