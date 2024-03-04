namespace Pharamcy.Domain.Models
{
    public class MedicineDefinition : BaseEntity
    {
        public  string EnglishName { get; set; }
        public  string ArabicName { get; set; }
        public  string Pharmacology { get; set; }
        public  string CompanyName { get; set; }
        public  string Type { get; set; }
        public int NationalCode { get; set; }
        public virtual List<MedicalEffectiveMaterial> EffectiveMaterials { get; set; }
    }
}
