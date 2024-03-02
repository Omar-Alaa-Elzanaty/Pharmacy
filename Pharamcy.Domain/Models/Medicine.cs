namespace Pharamcy.Domain.Models
{
    public class Medicine : BaseEntity
    {
        public int? ShortCode { get; set; }
        public long? BarCode1 { get; set; }
        public long? BarCode2 { get; set; }
        public long? BarCode3 { get; set; }
        public long? BarCode4 { get; set; }
        public long? BarCode5 { get; set; }
        public double PurchasePrice { get; set; }
        public bool AllowToPrint { get; set; }
        public int PharmacyId { get; set; }
        public int MinimumAmount { get; set; }
        public double BuyDiscount { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
        public int InfoId { get; set; }
        public virtual MedicineDefinition Information { get; set; }
        public long?[] BarCodes => [BarCode1, BarCode2, BarCode3, BarCode4, BarCode5];
    }
}
