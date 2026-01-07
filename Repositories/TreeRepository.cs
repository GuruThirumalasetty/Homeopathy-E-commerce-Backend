using Dapper;
using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Homeo_Mart.Services;
using System.Data;
using System.Net;
using static Homeo_Mart.Models.CommonResponse;

namespace Homeo_Mart.Repositories
{
    public class TreeRepository: BaseRepository, ITreeRepository
    {
        public TreeRepository(IConfiguration configuration) : base(configuration) { }

        private DynamicParameters BuileParams(Tree model, string action_type)
        {
            var p = new DynamicParameters();
            p.Add("p_action_type", action_type);
            p.Add("p_id", model.id);
            p.Add("p_name", model.name);
            p.Add("p_code", model.code);
            p.Add("p_parent_id", model.parent_id);
            p.Add("p_description", model.description);
            p.Add("p_is_chart_parent", model.is_chart_node);
            p.Add("p_chart_heading", model.chart_heading);
            p.Add("p_status", model.status);
            p.Add("p_created_by", model.created_by);
            p.Add("p_updated_by", model.updated_by);

            return p;
        }
        public async Task<ApiListResponse<Tree>> get_nodes_by_parent_id(Tree model)
        {
            try
            {
                var p = BuileParams(model, "get");

                var conn = GetConnection();
                var result = (await conn.QueryAsync<Tree>("hm_pr_manage_tree_master", p, commandType: CommandType.StoredProcedure)).ToList();

                return new ApiListResponse<Tree>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Nodes retrieved successfully.",
                    Data = result.ToList()
                };
            }
            catch (Exception ex)
            {
                return new ApiListResponse<Tree>
                {
                    status_code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = new List<Tree>()
                };
            }
        }

        public async Task<ApiResponse<int>> insert_node(Tree model)
        {
            try
            {
                var p = BuileParams(model, "insert");
                var conn = GetConnection();
                var result = await QuerySingleAsync<int>("hm_pr_manage_tree_master", p);

                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Node inserted successfully.",
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

        public async Task<ApiResponse<int>> update_node(Tree model)
        {
            try
            {
                var p = BuileParams(model, "update");
                var conn = GetConnection();
                var result = await QuerySingleAsync<int>("hm_pr_manage_tree_master", p);

                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Node updated successfully.",
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
