namespace Pharamcy.Domain.Models
{
    public class PurchaseInvoice: BaseEntity
    {
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }
        public double TotalCost { get;set; }
        public string ImportInvoiceNumber { get; set; }
        public string Notes { get; set; }
        public int DiscountCostPrecent { get; set; }
        public double TermAmount { get; set; }
        public double Paied { get; set; }
        public string CreatorName { get; set; }
        public bool IsClosed { get; set; }
        public string? InvoiceImageUrl { get; set; }
        public int PharmacyId { get; set;}
        public virtual Pharmacy Pharmacy { get; set; }
        public virtual List<PurchaseInvoiceItem> Items { get; set; } = new();  
    }
}
