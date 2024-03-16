using Mapster;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineByName;
using Pharamcy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Common.Mapping
{
    public class MedicineMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Medicine, GetMedicineByNameQueryDto>().Map(i=>i,i=>i.Tracking.LastOrDefault()); 
        }
    }
}
