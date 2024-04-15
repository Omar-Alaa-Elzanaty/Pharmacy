namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineForSalesInvoiceByName
{
    public class GetMedicineForSalesInvoiceByNameQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPartationing { get; set; }
        public List<MedicineDetails>? MedicineDetails { get; set; }
        public List<PartitionMedicineDetails>? PartitionMedicineDetails { get; set; }
    }
    public class MedicineDetails
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public double SalePrice { get; set; }
        public double PurchasePrice { get; set; }
        public DateOnly ExpireDate { get; set; }
    }

    public class PartitionMedicineDetails : MedicineDetails
    {
        public int TabletsAvailableAmount { get; set; }
        public int TapsAvailableAmount { get; set; }
        public double TabletSalePrice { get; set; }
    }

}
