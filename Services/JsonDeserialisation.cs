using System.Text.Json;

namespace Homeo_Mart.Services
{
    public static class CommonHelper
    {
        /// <summary>
        /// Universal JSON normalizer.
        /// Accepts string JSON or any object/list and returns valid JSON.
        /// </summary>
        public static string NormalizeJson(object? input)
        {
            // CASE 1 → Null
            if (input == null)
                return "[]";

            // CASE 2 → Input is JSON string
            if (input is string jsonString)
            {
                if (string.IsNullOrWhiteSpace(jsonString))
                    return "[]";

                try
                {
                    // Deserialize without knowing model
                    JsonElement element =
                        JsonSerializer.Deserialize<JsonElement>(jsonString);

                    // Serialize again to normalize
                    return JsonSerializer.Serialize(element);
                }
                catch
                {
                    return "[]";
                }
            }

            // CASE 3 → Any object / list / array / model
            try
            {
                // Serialize object
                string serialized = JsonSerializer.Serialize(input);

                // Deserialize to validate JSON
                JsonElement element =
                    JsonSerializer.Deserialize<JsonElement>(serialized);

                // Re-serialize normalized JSON
                return JsonSerializer.Serialize(element);
            }
            catch
            {
                return "[]";
            }
        }
    }
}
