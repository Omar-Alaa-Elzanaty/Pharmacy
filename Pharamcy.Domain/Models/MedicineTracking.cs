namespace Pharamcy.Domain.Models
{
    public class MedicineTracking : BaseEntity
    {
        public int PharmacyId { get; set; }
        public Pharmacy Pharmacy { get; set; }
        public int Amount { get; set; }
        public double SalePrice { get;set; }
        public double? TabletSalePrice { get; set; }
        public double? TapeSalePrice { get; set; }
    }
}
