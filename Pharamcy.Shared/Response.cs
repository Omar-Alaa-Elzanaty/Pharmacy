using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Shared
{
    public class Response
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = "";
        public object? Data { get; set; }
    }
}
