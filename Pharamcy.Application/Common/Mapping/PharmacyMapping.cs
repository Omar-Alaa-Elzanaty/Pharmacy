using Mapster;
using Pharamcy.Application.Features.Pharmacy.Commands.Create;
using Pharamcy.Application.Features.Pharmacy.Commands.DeleteById;
using Pharamcy.Application.Features.Pharmacy.Queries.GetAll;
using Pharamcy.Domain.Models;

namespace Pharamcy.Application.Common.Mapping
{
    public class PharmacyMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {

            config.NewConfig<CreatePharmacyCommand, Pharmacy>();
            config.NewConfig<DeleteByIdCommand, Pharmacy>();
            config.NewConfig<Pharmacy,GetAllPharmacyQuery>();
        }
    }
}
