namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByKeyCode
{
    public class GetPartitionMedicineByKeyCodeQueryDto : GetMedicineByKeyQueryDto
    {
        public int TapesAmount { get; set; }
        public int? TabletsAmount { get; set; }
    }
}
