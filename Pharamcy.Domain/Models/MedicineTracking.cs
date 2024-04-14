namespace Pharamcy.Domain.Models
{
    public class MedicineTracking : BaseEntity
    {
        public string? BarCode { get; set; }
        public int Amount { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public int MedicineId { get; set; }
        public DateOnly ExpireDate { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}

