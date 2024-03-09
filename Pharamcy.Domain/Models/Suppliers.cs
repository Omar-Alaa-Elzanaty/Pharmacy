namespace Pharamcy.Domain.Models
{
    public class Suppliers : BaseEntity
    {
        public string Name { get; set; }
        public int PharamcyId { get; set; }
        public virtual Pharmacy Pharmacy { get; set; }
    }
}
