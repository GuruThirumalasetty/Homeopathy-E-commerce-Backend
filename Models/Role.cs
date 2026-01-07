namespace Homeo_Mart.Models
{
    public class role
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public int status { get; set; }

        public int created_by { get; set; }
        public int updated_by { get; set; }

        // JSON from DB
        public string? permissions { get; set; }

        // Object/List from Angular
        public List<role_permission>? permissions_list { get; set; }
    }

    public class role_permission
    {
        public int id { get; set; }
        public int permission_id { get; set; }
        public string? permission_name { get; set; }
        public string? description { get; set; }
        public string? link { get; set; }
        public int? is_nav_visible { get; set; }
        public string? icon { get; set; }

        public int is_create { get; set; }
        public int is_update { get; set; }
        public int is_view { get; set; }
        public int is_delete { get; set; }

        public int status { get; set; }
    }
}
