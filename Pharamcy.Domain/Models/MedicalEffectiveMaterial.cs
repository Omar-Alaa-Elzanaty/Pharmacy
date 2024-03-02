namespace Pharamcy.Domain.Models
{
    public class MedicalEffectiveMaterial : BaseEntity
    {
        public virtual List<MedicineDefinition> Medicines { get; set; }
    }
}
