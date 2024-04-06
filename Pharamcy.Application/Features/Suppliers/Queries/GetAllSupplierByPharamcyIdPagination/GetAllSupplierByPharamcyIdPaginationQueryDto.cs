namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllSupplierByPharamcyIdPagination
{
    public class GetAllSupplierByPharamcyIdPaginationQueryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double FinancialDue { get; set; }
    }
}
