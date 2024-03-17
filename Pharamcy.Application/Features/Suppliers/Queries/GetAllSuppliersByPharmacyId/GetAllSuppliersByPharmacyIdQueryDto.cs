using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllSuppliersByPharmacyId
{
    public class GetAllSuppliersByPharmacyIdQueryDto
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public double FinancialDue { get; set; }

    }
}
