using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class PartitionMedicineTracking:BaseEntity
    {
        public string BarCode { get; set; }
        public int Amount { get; set; }
        public double SalePrice { get; set; }
        public double TabletSalePrice { get; set; }
        public double? TapeSalePrice { get; set; }
        public int PartitionMedicineId { get; set; }
    }
}
