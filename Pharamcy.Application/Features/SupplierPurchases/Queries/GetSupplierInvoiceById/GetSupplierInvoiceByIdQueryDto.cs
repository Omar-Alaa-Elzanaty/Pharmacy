using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetSupplierInvoiceById
{
    public class GetSupplierInvoiceByIdQueryDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public double TotalCost { get; set; }
        public string ImportInvoiceNumber { get; set; }
        public string Notes { get; set; }
        public int DiscountCostPrecent { get; set; }
        public double TermAmount { get; set; }
        public double Paied { get; set; }
        public string CreatorName { get; set; }
        public bool IsClosed { get; set; }
        public string? InvoiceImageUrl { get; set; }
    }
}
