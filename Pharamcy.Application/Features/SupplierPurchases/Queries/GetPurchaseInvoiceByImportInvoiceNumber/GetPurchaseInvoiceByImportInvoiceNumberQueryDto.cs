using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetPurchaseInvoiceByImportInvoiceNumber
{
    public class GetPurchaseInvoiceByImportInvoiceNumberQueryDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string SupplierName { get; set; }
        public double TotalCost { get; set; }
        public string ImportInvoiceNumber { get; set; }
        public string Notes { get; set; }
        public int DiscountCostPrecent { get; set; }
        public double TermAmount { get; set; }
        public double Paied { get; set; }
        public string CreatorName { get; set; }
        public bool IsClosed { get; set; }
        public string? InvoiceImageUrl { get; set; }
        public int PharmacyId { get; set; }
        public List<GetPurchaseInvoiceItemsByImportInvoiceNumberQueryDto> Items { get; set; }
    }

    public class GetPurchaseInvoiceItemsByImportInvoiceNumberQueryDto
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
    }
}
