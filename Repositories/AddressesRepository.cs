using Dapper;
using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Homeo_Mart.Services;
using System.Data;
using System.Net;
using static Homeo_Mart.Models.CommonResponse;

namespace Homeo_Mart.Repositories
{
    public class AddressesRepository : BaseRepository, IAddressesRepository
    {
        public AddressesRepository(IConfiguration configuration) : base(configuration) { }

        // Build stored procedure params
        private DynamicParameters BuildParams(Address model, string action)
        {
            var p = new DynamicParameters();
            p.Add("p_action_type", action);
            p.Add("p_id", model.id);
            p.Add("p_user_id", model.user_id);
            p.Add("p_address", model.address);
            p.Add("p_phone_number", model.phone_number);
            p.Add("p_street", model.street);
            p.Add("p_city", model.city);
            p.Add("p_state", model.state);
            p.Add("p_zip_code", model.zip_code);
            p.Add("p_country", model.country);
            p.Add("p_set_as_default", model.set_as_default);
            p.Add("p_status", model.status);
            p.Add("p_created_by", model.created_by);
            p.Add("p_updated_by", model.updated_by);
            return p;
        }

        // ----------------------------------------------------------
        // GET ADDRESSES
        // ----------------------------------------------------------
        public async Task<ApiListResponse<Address>> GetAddressesAsync(Address model)
        {
            try
            {
                var p = BuildParams(model, "get");

                var conn = GetConnection();
                var result = (await conn.QueryAsync<Address>(
                "hm_pr_manage_addresses",
                p,
                commandType: CommandType.StoredProcedure
            )).ToList(); ;

                return new ApiListResponse<Address>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Addresses retrieved successfully",
                    Data = result.ToList()
                };
            }
            catch (Exception ex)
            {
                return new ApiListResponse<Address>
                {
                    status_code = HttpStatusCode.InternalServerError,
                    Message = $"Failed to get addresses: {ex.Message}",
                    Data = new List<Address>()
                };
            }
        }

        // ----------------------------------------------------------
        // INSERT ADDRESS
        // ----------------------------------------------------------
        public async Task<ApiResponse<int>> InsertAddressesAsync(Address model)
        {
            try
            {
                var p = BuildParams(model, "insert");

                var result = await QuerySingleAsync<int>("hm_pr_manage_addresses", p);

                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Address inserted successfully",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.InternalServerError,
                    Message = $"Insertion failed: {ex.Message}",
                    Data = 0
                };
            }
        }

        // ----------------------------------------------------------
        // UPDATE ADDRESS
        // ----------------------------------------------------------
        public async Task<ApiResponse<int>> UpdateAddressesAsync(Address model)
        {
            try
            {
                var p = BuildParams(model, "update");

                var result = await QuerySingleAsync<int>("hm_pr_manage_addresses", p);

                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Address updated successfully",
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

        // ----------------------------------------------------------
        // STATUS UPDATE (ACTIVE/INACTIVE)
        // ----------------------------------------------------------
        public async Task<ApiResponse<int>> StatusUpdateAddressesAsync(Address model)
        {
            try
            {
                var p = BuildParams(model, "status_update");

                var result = await QuerySingleAsync<int>("hm_pr_manage_addresses", p);

                return new ApiResponse<int>
                {
                    status_code = HttpStatusCode.OK,
                    Message = "Address status updated successfully",
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
    }
}
