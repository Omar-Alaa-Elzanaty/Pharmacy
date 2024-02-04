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
        [ForeignKey("pharmacy")]
        public int PId { get; set; }
        public Pharmacy pharmacy { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }
}
