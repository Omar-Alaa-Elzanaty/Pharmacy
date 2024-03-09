namespace Pharamcy.Domain.Models
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public int PharamcyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
    }
}
