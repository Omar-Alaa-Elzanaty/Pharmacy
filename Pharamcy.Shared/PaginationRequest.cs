using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Shared
{
    public record PaginationRequest
    {
        public string? KeyWord { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set;}
    }
}
