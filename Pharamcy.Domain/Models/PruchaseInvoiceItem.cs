using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class PruchaseInvoiceItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public int shelf { get; set; }
        public double UnitPrice { get; set; }
        public string? InvoiceImage { get; set; }
        public int StripsCount { get; set; }
        public virtual PurchaseInvoice PurchaseInvoice { get; set; }
        public int TaxiPrecent { get; set; }
        public int Bonus { get; set; }
        public int AdditionalDiscount { get; set; }
        public int pharmaceuticalDiscount { get; set; }
        public double BuyPrice { get; set; }
        public double SalePrice => Quantity * UnitPrice;
        public DateOnly ExpireDate { get; set; }
    }
}
