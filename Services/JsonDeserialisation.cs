using Homeo_Mart.Models;
using System.Text.Json;

namespace Homeo_Mart.Services
{

    public static class CommonHelper
    {
        public static string JsonDeserialisation(string json, List<product_file>? jsonList)
        {
            if (!string.IsNullOrWhiteSpace(json))
            {
                try
                {
                    var parsed = JsonSerializer.Deserialize<List<object>>(json);
                    return JsonSerializer.Serialize(parsed);
                }
                catch
                {
                    return "[]";
                }
            }

            // CASE 2 → Angular sent files_list instead
            if (jsonList != null && jsonList.Count > 0)
            {
                return JsonSerializer.Serialize(jsonList);
            }

            // CASE 3 → No files provided
            return "[]";
        }
    }
}
