namespace Homeo_Mart.Models
{
    public class Tree
    {
        public int? id { get; set; }
        public int? parent_id { get; set; }
        public string? name { get; set; }
        public string? code { get; set; }
        public string? description { get; set; }
        public int? is_chart_node { get; set; }
        public string? chart_heading { get; set; }
        public int? status { get; set; }
        public DateTime? created_on{ get; set; }
        public int? created_by{ get; set; }
        public DateTime? updated_on{ get; set; }
        public int? updated_by{ get; set; }
    }
}
