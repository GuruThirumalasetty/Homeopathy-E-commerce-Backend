namespace Homeo_Mart.Models
{
    public class CategoryCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Status { get; set; } = "Active";
        public string CreatedBy { get; set; } = string.Empty;
    }
}