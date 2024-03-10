namespace Pharamcy.Domain.Models
{
    public class MedicineTracking : BaseEntity
    {
        public string? BarCode { get; set; }
        public int Amount { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
    }
}

