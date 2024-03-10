namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCode
{
    public class GetPartitionMedicineByBarCodeQueryDto : GetMedicineByBarCodeQueryDto
    {
        public int TapesAmount { get; set; }
        public int? TabletsAmount { get; set; }
    }
}
