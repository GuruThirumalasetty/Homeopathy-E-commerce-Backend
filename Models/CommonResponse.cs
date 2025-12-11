using System.Net;

namespace Homeo_Mart.Models
{
    public class CommonResponse
    {
        public class ApiListResponse<T>
        {
            //public HttpStatusCode Status_code { get; set; }
            public HttpStatusCode status_code { get; set; }
            public string ?Message { get; set; }
            public IEnumerable<T> ?Data { get; set; }
        }
        public class ApiResponse<T>
        {
            public HttpStatusCode status_code { get; set; }
            public string ?Message { get; set; }
            public T? Data { get; set; }
        }


    }
}
