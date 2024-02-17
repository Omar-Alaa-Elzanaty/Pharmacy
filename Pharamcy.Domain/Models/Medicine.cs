using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class Medicine : BaseEntity  
    {
        public int PharmacyId { get; set; }
        public virtual Pharmacy pharmacy { get; set; }
    }
}
