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
        public virtual SalesInvoice SalesInvoice { get; set; }
    }
}
