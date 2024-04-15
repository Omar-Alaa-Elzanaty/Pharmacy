using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.SaleInvoice.Queries.GetSaleInvoiceByIdPagination
{
    public class GetSaleInvoiceByIdPaginationQueryDto
    {
        public DateTime CreatedDate { get; set; }
        public string ClientName { get; set; }
        public int ClientId { get; set; }
        public int Quantity { get; set; }
        public double TotalCost { get; set; }
        public double Discount { get; set; }
        public double Due { get; set; }
    }
}
