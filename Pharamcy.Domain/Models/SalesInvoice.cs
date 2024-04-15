namespace Pharamcy.Domain.Models
{
    public class SalesInvoice : BaseEntity 
    {
        public double TotalOfSalePrice { get; set; }
        public double TotalDiscount { get; set; }
        public double AdditionalValue { get; set; }
        public double TotalOfSalePriceAfterDiscount { get; set; }
        public double Paied { get; set; }
        public double TermAmount { get; set; }
        public string DeliveryName { get; set; }
        public string Notes { get; set; }
        public string InvoiceWriter { get; set; }
        public int? ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public int PharmacyId { get; set; }
        public virtual List<SalesInvoiceItem> Items { get; set; }
    }
}
