using Mapster;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineByName;
using Pharamcy.Domain.Models;

namespace Pharamcy.Application.Common.Mapping
{
    public class MedicineMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Medicine, GetMedicineByNameQueryDto>().Map(i => i, i => i.Tracking.OrderByDescending(i => i.Id).FirstOrDefault());

            config.NewConfig<PartitionMedicine, GetMedicineByNameQueryDto>().Map(i => i, i => i.PartitionMedicineTrackings.OrderByDescending(i => i.Id).FirstOrDefault());
        }
    }
}
