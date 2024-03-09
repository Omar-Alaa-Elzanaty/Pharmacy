namespace Pharamcy.Domain.Models
{
    public class FinancialDues : BaseEntity
    {
        public int SupplierId { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public double FinancialDue { get; set; }
    }
}
