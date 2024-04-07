namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllSuppliersByPharmacyId
{
    public class GetAllSuppliersByPharmacyIdQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double FinancialDue { get; set; }
    }
}
