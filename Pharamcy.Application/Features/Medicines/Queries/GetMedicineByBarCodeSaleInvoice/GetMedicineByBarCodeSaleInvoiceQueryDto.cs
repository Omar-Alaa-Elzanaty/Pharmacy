using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCodeSaleInvoice
{
    public class GetMedicineByBarCodeSaleInvoiceQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPartationing { get; set; }
        public MedicineDetailsByBarCode MedicineDetails { get; set; }
        public PartitionMedicineDetailsByBarCode? PartitionMedicineDetails { get; set; }
    }
    public class MedicineDetailsByBarCode
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double SalePrice { get; set; }
        public double PurchasePrice { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class PartitionMedicineDetailsByBarCode : MedicineDetailsByBarCode
    {
        public int TabletsAvailableAmount { get; set; }
        public int TapsAvailableAmount { get; set; }
        public double TabletSalePrice { get; set; }
    }
}
