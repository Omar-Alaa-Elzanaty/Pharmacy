using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class Store:BaseEntity
    {
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}
