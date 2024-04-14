using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class SalesInvoiceItem:BaseEntity
    {
        public int SalesInvoiceId { get; set; }
        public int? Amount { get; set; }
        public int? Taps { get; set; }
        public int? Tablets { get; set; }
        public double SalePrice { get; set; }
        public int Discount { get; set; }
        public int Taxis { get; set; }
        public double PriceAfterDiscount { get; set; }
        public DateOnly ExpireDate { get; set; }


        public virtual SalesInvoice SalesInvoice { get; set; }
    }
}
