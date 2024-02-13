using Mapster;
using Pharamcy.Application.Features.Pharmacy.Commands.CreateCommand;
using Pharamcy.Application.Features.Pharmacy.Commands.DeleteByIdCommand;
using Pharamcy.Domain.Models;

namespace Pharamcy.Application.Common.Mapping
{
    public class PharmacyMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<CreatePharmacyCommand, Pharmacy>();
            config.NewConfig<DeleteByIdCommand, Pharmacy>();
        }
    }
}
