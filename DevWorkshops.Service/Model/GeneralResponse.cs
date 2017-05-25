using System;
using System.Net;

namespace DevWorkshops.Service.Model
{
    public class GeneralResponse
    {
        public bool IsSuccess { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ResponseContentString { get; set; }
    }
}
