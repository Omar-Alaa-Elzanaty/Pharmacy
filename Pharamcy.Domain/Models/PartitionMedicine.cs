namespace Pharamcy.Domain.Models
{
    public class PartitionMedicine : BaseMedicine
    {
        public virtual List<PartitionMedicineTracking> Tracking { get; set; } = new();

    }
}
