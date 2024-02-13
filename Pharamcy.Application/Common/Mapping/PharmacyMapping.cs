using Mapster;
using Pharamcy.Application.Features.Pharmacy.CreatePharmacyCommand;
using Pharamcy.Domain.Models;

namespace Pharamcy.Application.Common.Mapping
{
    public class PharmacyMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<CreatePharmacyCommand,Pharmacy>();
        }
    }
}
