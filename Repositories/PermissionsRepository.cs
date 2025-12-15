using Dapper;
using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Homeo_Mart.Services;
using System.Data;
using System.Net;
using static Homeo_Mart.Models.CommonResponse;

namespace Homeo_Mart.Repositories
{
    public class PermissionsRepository: BaseRepository, IPermissionsRepository
    {
        public PermissionsRepository(IConfiguration configuration): base(configuration) { }

        private DynamicParameters BuildParams(Permission model, string action)
        {
            var p = new DynamicParameters();
            p.Add("p_action_type", action);
            p.Add("p_id", model.id);
            p.Add("p_name", model.name);
            p.Add("p_description", model.description);
            p.Add("p_link", model.link);
            p.Add("p_is_nav_visible", model.is_nav_visible);
            p.Add("p_icon", model.icon);
            p.Add("p_status", model.status);
            p.Add("p_is_create_disable", model.is_create_disable);
            p.Add("p_is_update_disable", model.is_update_disable);
            p.Add("p_is_view_disable", model.is_view_disable);
            p.Add("p_is_delete_disable", model.is_delete_disable);
            p.Add("p_created_by", model.created_by);
            p.Add("p_updated_by", model.updated_by);

            return p;
        }

        public async Task<ApiListResponse<Permission>> get_permissions(Permission model)
        {
            try
            {
                var p = BuildParams(model, "get");

                var conn = GetConnection();
                var result = (await conn.QueryAsync<Permission>(
                    "hm_pr_manage_permissions",
                    p,
                    commandType: CommandType.StoredProcedure
                )).ToList();

                return new ApiListResponse<Permission>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Permissions retrieved successfully.",
                    Data = result.ToList()
                };
            }
            catch (Exception ex)
            {
                return new ApiListResponse<Permission>
                {
                    status_code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = new List<Permission>()
                };
            }
        }
        public async Task<ApiResponse<int>> insert_permissions(Permission model)
        {
            try
            {
                var p = BuildParams(model, "insert");

                var result = await QuerySingleAsync<int>("hm_pr_manage_permissions", p);

                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Permissions inserted successfully.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = 0
                };
            }
        }
        public async Task<ApiResponse<int>> update_permissions(Permission model)
        {
            try
            {
                var p = BuildParams(model, "update");

                var result = await QuerySingleAsync<int>("hm_pr_manage_permissions", p);

                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Permission updated successfully.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = 0
                };
            }
        }
        public async Task<ApiResponse<int>> status_update_permissions(Permission model)
        {
            try
            {
                var p = BuildParams(model, "status_update");

                var result = await QuerySingleAsync<int>("hm_pr_manage_permissions", p);

                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Permission status has been updated successfully.",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = 0
                };
            } 
            
        }
    }
}
