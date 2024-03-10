using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCode
{
    public class GetMedicineByBarCodeQueryDto
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public int Amount { get; set; }
        public decimal PurchasePrice { get; set; }
        public int BaseDiscount { get; set; }
        public decimal SellingPrice { get; set; }
        public int AdditionalTaxes { get; set; }
    }
}
