namespace Homeo_Mart.Models
{
    public class Permission
    {
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? link { get; set; }
        public int? is_nav_visible { get; set; }
        public string? icon { get; set; }
        public int? status { get; set; }
        public int? is_create_disable { get; set; }
        public int? is_update_disable { get; set; }
        public int? is_view_disable { get; set; }
        public int? is_delete_disable { get; set; }
        public DateTime? created_on { get; set; }
        public int? created_by { get; set; }
        public DateTime? updated_on { get; set; }
        public int? updated_by { get; set; }
    }
}
