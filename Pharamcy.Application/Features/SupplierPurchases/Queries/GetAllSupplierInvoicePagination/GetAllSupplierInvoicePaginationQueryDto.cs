using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetAllSupplierInvoicePagination
{
    public class GetAllSupplierInvoicePaginationQueryDto
    {
        public int Id { get; set; }
        public string ImportInvoiceNumber { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
