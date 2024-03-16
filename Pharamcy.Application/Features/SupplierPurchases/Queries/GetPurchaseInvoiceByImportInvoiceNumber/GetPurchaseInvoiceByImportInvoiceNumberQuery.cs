using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetPurchaseInvoiceByImportInvoiceNumber
{
    public class GetPurchaseInvoiceByImportInvoiceNumberQuery
    {
        public int PharmacyId { get; set; }
        public int ImportInvoiceNumber { get; set; }
    }
}
