using Homeo_Mart.Models;
using static Homeo_Mart.Models.CommonResponse;

namespace Homeo_Mart.Interfaces
{
    public interface IAddressesRepository
    {
        Task<ApiListResponse<Address>> GetAddressesAsync(Address model);
        Task<ApiResponse<int>> InsertAddressesAsync(Address model);
        Task<ApiResponse<int>> UpdateAddressesAsync(Address model);
        Task<ApiResponse<int>> StatusUpdateAddressesAsync(Address model);
    }
}
