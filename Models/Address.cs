namespace Homeo_Mart.Models
{
    public class Address
    {
        public string? action_type {  get; set; }
        public int ?id { get; set; }
        public int user_id { get; set; }
        public string? address { get; set; }
        public string ?phone_number { get; set; }
        public string ?street { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? zip_code { get; set; }
        public string? country { get; set; }
        public int? set_as_default { get; set; }
        public int? status { get; set; }
        public DateTime? created_on { get; set; }
        public int? created_by { get; set; }
        public DateTime? updated_on { get; set; }
        public int? updated_by { get;set; }


    }
}
