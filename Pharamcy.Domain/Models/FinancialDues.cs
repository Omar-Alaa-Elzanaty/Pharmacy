namespace Pharamcy.Domain.Models
{
    public class FinancialDues : BaseEntity
    {
        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public double FinancialDue { get; set; }
    }
}
