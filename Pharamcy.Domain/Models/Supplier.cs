using Pharamcy.Domain.Comman.Enums;

namespace Pharamcy.Domain.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public double FinancialDue { get; set; }
        public SupplierType Type { get; set; }
        public int PharmacyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; } 
    }
}
