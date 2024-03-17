namespace Pharamcy.Domain.Models
{
    public class MedicalEffectiveMaterial : BaseEntity
    {
        public string Name { get; set; }
        public virtual List<MedicineDefinition> Medicines { get; set; }
    }
}
