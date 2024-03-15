using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class PurchaseInvoiceItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Bonse { get; set; }
        public int Shelf { get; set; } = 0;
        public double UnitPrice { get; set; }
        public int Taps { get; set; }
        public int Tablets { get; set; }
        public int Taxis { get; set; }
        public int AdditionalDiscount { get; set; }
        public int BaseDiscount { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public DateOnly ExpireDate { get; set; }

        public double TabletSalePrice { get; set; }

        public bool IsPartition { get; set; }
        public int PurchaseInvoiceId { get; set; }
        public virtual PurchaseInvoice PurchaseInvoice { get; set; }
    }
}
