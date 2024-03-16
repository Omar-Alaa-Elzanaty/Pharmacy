using Mapster;
using Pharamcy.Application.Features.SystemAdmin.Queries.GetAllSystemAdminOrAdminPagination;
using Pharamcy.Application.Features.SystemAdmin.Queries.GetSystemAdminOrAdminById;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Common.Mapping
{
    public class SystemAdminMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ApplicationUser, GetSystemAdminOrAdminByIdDto>();

        }
    }
}
