using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByNamePagination
{
    public class GetMedicineByNamePaginationQueryDto
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public int Amount { get; set; }
        public double SalePrice { get; set; }
        public bool IsPartationing { get; set; }
    }
}
