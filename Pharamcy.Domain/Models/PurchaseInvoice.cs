namespace Pharamcy.Domain.Models
{
    public class PurchaseInvoice : BaseEntity
    {
        public string CompanyName { get; set; }
        public double TotalCost { get;set; }
        public string ImportInvoiceNumber { get; set; }
        public string Notes { get; set; }
        public int DiscountCostPrecent { get; set; }
        public double TermAmount { get; set; }
        public double Paied { get; set; }
        public string CreatorName { get; set; }
        public int serialNumber { get; set; }
        public bool IsClosed { get; set; }
        public string? InvoiceImage { get; set; }
        public virtual List<PruchaseInvoiceItem> Items { get; set; }
    }
}
