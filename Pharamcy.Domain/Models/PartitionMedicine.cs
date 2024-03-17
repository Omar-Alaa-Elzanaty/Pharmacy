namespace Pharamcy.Domain.Models
{
    public class PartitionMedicine : BaseMedicine
    {
        public virtual List<PartitionMedicineTracking> PartitionMedicineTrackings { get; set; } = new();

    }
}
