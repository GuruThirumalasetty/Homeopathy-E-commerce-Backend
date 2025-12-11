using Dapper;
using Homeo_Mart.Interfaces;
using Homeo_Mart.Models;
using Homeo_Mart.Models.Homeo_Mart.Models;
using Homeo_Mart.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;
using static Homeo_Mart.Models.CommonResponse;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(IConfiguration configuration) : base(configuration) { }

    // Build Params (DO NOT CHANGE THIS)
    private DynamicParameters BuildParams(product model, string action)
    {
        var p = new DynamicParameters();
        p.Add("p_action_type", action);
        p.Add("p_id", model.id);
        p.Add("p_name", model.name);
        p.Add("p_code", model.code);
        p.Add("p_type", model.type);
        p.Add("p_contributor_name", model.contributor_name);
        p.Add("p_category_id", model.category_id);
        p.Add("p_stock_quantity", model.stock_quantity);
        p.Add("p_price", model.price);
        p.Add("p_discount_type", model.discount_type);
        p.Add("p_discount", model.discount);
        p.Add("p_rating", model.rating);
        p.Add("p_description", model.description);
        p.Add("p_shipping_charges", model.shipping_charges);
        p.Add("p_tax", model.tax);
        p.Add("p_status", model.status);
        p.Add("p_created_by", model.created_by);
        p.Add("p_updated_by", model.updated_by);
        p.Add("p_filesJSON", CommonHelper.JsonDeserialisation(model.filesjson, model.files_list));
        return p;
    }

    // ➤ INSERT PRODUCT
    public async Task<ApiResponse<object>> Insert(product model)
    {
        try
        {
            var parameters = BuildParams(model, "insert");

            using var conn = GetConnection();
            var result = await conn.QueryFirstOrDefaultAsync<object>(
                "hm_manage_product",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return new ApiResponse<object>
            {
                status_code = HttpStatusCode.OK,
                Message = "Product inserted successfully",
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Insert failed: {ex.Message}",
                Data = null
            };
        }
    }

    // ➤ UPDATE PRODUCT
    public async Task<ApiResponse<object>> Update(product model)
    {
        try
        {
            var parameters = BuildParams(model, "update");

            using var conn = GetConnection();
            var result = await conn.QueryFirstOrDefaultAsync<object>(
                "hm_manage_product",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return new ApiResponse<object>
            {
                status_code = HttpStatusCode.OK,
                Message = "Product updated successfully",
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Update failed: {ex.Message}",
                Data = null
            };
        }
    }

    // ➤ GET ALL / GET BY ID
    public async Task<ApiListResponse<product>> Get(product model)
    {
        try
        {
            var parameters = BuildParams(model, "get");

            using var conn = GetConnection();
            var list = await conn.QueryAsync<product>(
                "hm_manage_product",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.files))
                {
                    try
                    {
                        item.files_list = JsonSerializer.Deserialize<List<product_file>>(item.files);
                        item.files = null;
                    }
                    catch
                    {
                        item.files_list = new List<product_file>();
                    }
                }
            }
            bool hasData = list.Any();

            return new ApiListResponse<product>
            {
                status_code = hasData ? HttpStatusCode.OK : HttpStatusCode.NotFound,
                Message = hasData ? "Products fetched successfully" : "No products found",
                Data = list
            };
        }
        catch (Exception ex)
        {
            return new ApiListResponse<product>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Error fetching products: {ex.Message}",
                Data = Enumerable.Empty<product>()
            };
        }
    }

    // ➤ STATUS UPDATE (SOFT DELETE)
    public async Task<ApiResponse<object>> StatusUpdate(product model)
    {
        try
        {
            var parameters = BuildParams(model, "status_update");

            using var conn = GetConnection();
            var result = await conn.QueryFirstOrDefaultAsync<object>(
                "hm_manage_product",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            return new ApiResponse<object>
            {
                status_code = HttpStatusCode.OK,
                Message = "Product status updated successfully",
                Data = result
            };
        }
        catch (Exception ex)
        {
            return new ApiResponse<object>
            {
                status_code = HttpStatusCode.InternalServerError,
                Message = $"Status update failed: {ex.Message}",
                Data = null
            };
        }
    }
}
