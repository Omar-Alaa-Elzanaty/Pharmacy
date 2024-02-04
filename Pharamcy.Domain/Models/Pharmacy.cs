using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Domain.Models
{
    public class Pharmacy:BaseEntity
    {
        public List<Medicine> Medicines { get; set; } = new();
        public List<PurchaseInvoices>  PurchaseInvoices { get; set; } = new();
        public List<SalesInvoices>  SalesInvoices{ get; set; } = new();
        public List<Clients>  Clients { get; set; } = new();
        public List<LostPofit>  LostPofits  { get; set; } = new();

    }
}
