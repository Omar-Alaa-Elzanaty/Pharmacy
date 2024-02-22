using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class Medicine : BaseEntity  
    {
        public string Name { get; set; }
        public int NationalCode { get; set; }
    }
}
