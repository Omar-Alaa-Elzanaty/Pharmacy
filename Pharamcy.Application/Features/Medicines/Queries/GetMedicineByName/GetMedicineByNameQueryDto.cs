using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByName
{
    public class GetMedicineByNameQueryDto
    {
        public int Id { get; set; }
        public string EnglishName { get; set; }
        public int Amount { get; set; }
        public double SalePrice { get; set; }
        public bool IsPartationing { get; set; }





    }
}
