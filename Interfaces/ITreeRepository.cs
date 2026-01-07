using Homeo_Mart.Models;
using static Homeo_Mart.Models.CommonResponse;

namespace Homeo_Mart.Interfaces
{
    public interface ITreeRepository
    {
        Task<ApiListResponse<Tree>> get_nodes_by_parent_id(Tree model);
        Task<ApiResponse<int>> insert_node(Tree model);
        Task<ApiResponse<int>> update_node(Tree model);
        //Task<ApiResponse<int>> status_update_node(Tree model);
    }
}
