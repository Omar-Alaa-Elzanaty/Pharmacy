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
        public List<PurchaseInvoice>  PurchaseInvoices { get; set; } = new();
        public List<SalesInvoice>  SalesInvoices{ get; set; } = new();
        public List<Client>  Clients { get; set; } = new();
        public List<Lost>  LostPofits  { get; set; } = new();

    }
}
