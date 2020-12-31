using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Web.Models
{
    public class RequestStatusViewModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
