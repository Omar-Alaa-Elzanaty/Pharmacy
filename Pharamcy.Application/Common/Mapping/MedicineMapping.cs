using Mapster;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCode;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineByName;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineForSalesInvoiceByName;
using Pharamcy.Domain.Models;

namespace Pharamcy.Application.Common.Mapping
{
    public class MedicineMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Medicine, GetMedicineByNameQueryDto>().Map(i => i, i => i.Tracking.LastOrDefault());
            
            config.NewConfig<Medicine, GetMedicineByBarCodeQueryDto>().Map(i => i, i => i.Tracking.LastOrDefault());

            config.NewConfig<PartitionMedicine, GetMedicineByNameQueryDto>().Map(i => i, i => i.Tracking.LastOrDefault());
            
            config.NewConfig<PartitionMedicine, GetPartitionMedicineByBarCodeQueryDto>().Map(i => i, i => i.Tracking.LastOrDefault());
        }
    }
}
