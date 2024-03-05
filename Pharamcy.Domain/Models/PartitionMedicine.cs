namespace Pharamcy.Domain.Models
{
    public class PartitionMedicine : Medicine
    {
        public virtual List<PartitionMedicineTracking> PartitionMedicineTrackings { get; set; } = new();

    }
}
