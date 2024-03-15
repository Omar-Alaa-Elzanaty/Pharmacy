using Microsoft.AspNetCore.Http;
using Pharamcy.Application.Features.SupplierPurchases.Commands.SavePurchaseCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetPurchaseInvoiceByImportInvoiceNumber
{
    
    public class MedicineItem
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Bonse { get; set; }

        public decimal UnitPrice { get; set; }
        public int Taps { get; set; }
        public int Tablets { get; set; }
        public int Taxis { get; set; }
        public int BaseDiscount { get; set; }
        public int AdditionalDiscount { get; set; }
        public double PurchasePrice { get; set; }
       
        public double SalePrice { get; set; }
        public double TabletSalePrice { get; set; }
        public DateOnly ExpireDate { get; set; }
    }
    public class GetPurchaseInvoiceByImportInvoiceNumberQueryDto
    {
        public List<MedicineItem> Items { get; set; }
        public bool IsClosed { get; set; }
        public double TermAmount { get; set; }
        public int DiscountCostPrecent { get; set; }
        public string CreatorName { get; set; }
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }


        public double TotalCost { get; set; }
        public double Paied { get; set; }
        public string ImportInvoiceNumber { get; set; }
        public string Notes { get; set; }
        public string? InvoiceImage { get; set; }
        public int PharmacyId { get; set; }
    }
}
