namespace Pharamcy.Domain.Models
{
    public class MedicineDefinition : BaseEntity
    {
        public required string EnglishName { get; set; }
        public required string ArabicName { get; set; }
        public required string Pharmacology { get; set; }
        public required string CompanyName { get; set; }
        public required string Type { get; set; }
        public int NationalCode { get; set; }
        public virtual List<MedicalEffectiveMaterial> EffectiveMaterials { get; set; }
    }
}
