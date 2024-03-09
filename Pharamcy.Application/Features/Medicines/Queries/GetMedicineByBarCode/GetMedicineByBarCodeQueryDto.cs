using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCode
{
    public class GetMedicineByBarCodeQueryDto
    {
        public int Id { get; set; }
        public bool IsPartition { get; set; }
        public string EnglishName { get; set; }
        public int Amount { get; set; }
        public int TapesAmount { get; set; }
        public int TabletAmount { get; set; }

    }
}
