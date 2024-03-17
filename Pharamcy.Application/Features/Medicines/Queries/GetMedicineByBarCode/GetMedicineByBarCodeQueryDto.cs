namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCode
{
    public class GetMedicineByBarCodeQueryDto
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public int Amount { get; set; }
        public double PurchasePrice { get; set; }
        public int BaseDiscount { get; set; }
        public double SellingPrice { get; set; }
        public int AdditionalTaxes { get; set; }
        public bool IsPartationing { get; set; }
    }
}
