namespace Homeo_Mart.Models
{
    public class Category
    {
        public int ?id { get; set; } = null;
        public string name { get; set; } = string.Empty;
        public string code { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int status { get; set; } = int.MinValue;
        public DateTime created_on { get; set; } = DateTime.MinValue;
        public int created_by { get; set; } = int.MinValue;
        public DateTime ?updated_on { get; set; } = null;
        public int ?updated_by { get; set; } = null;
    }
}
