namespace Homeo_Mart.Models
{
    using System.Text.Json.Serialization;

    namespace Homeo_Mart.Models
    {
        public class product
        {
            public string? action_type { get; set; }

            public int? id { get; set; }
            public string? name { get; set; }
            public string? code { get; set; }
            public string? type { get; set; }
            public string? contributor_name { get; set; }
            public int? category_id { get; set; }
            public string? category_name { get; set; }
            public int? stock_quantity { get; set; }
            public decimal? price { get; set; }
            public string? discount_type { get; set; }
            public decimal? discount { get; set; }
            public decimal? rating { get; set; }
            public string? description { get; set; }
            public int? shipping_charges { get; set; }
            public int? tax { get; set; }
            public int? status { get; set; }
            public DateTime? created_on { get; set; }
            public int? created_by { get; set; }
            public int? updated_by { get; set; }
            public DateTime? updated_on { get; set; }

            // JSON string for input (Angular sends it)
            public string? filesjson { get; set; }

            // JSON string returned from MySQL
            public string? files { get; set; }

            // Parsed version of files (list)
            public List<product_file>? files_list { get; set; }
        }

    }


    public class product_file
    {
        public int? id { get; set; }
        public int? product_id { get; set; }
        public string? file_name { get; set; }
        public string? file_path { get; set; }
        public string? file_type { get; set; }
        public int? status { get; set; }
        public int? mode { get; set; }
        public string? created_on { get; set; }
        public int? created_by { get; set; }
        public string? updated_on { get; set; }
        public int? updated_by { get; set; }
    }


}
