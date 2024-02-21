using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Pharamcy.Application.Features.SystemAdmin.Queries.GetAllSystemAdminAndAdmin;
using Pharamcy.Application.Features.SystemAdmin.Queries.GetSystemAdminOrAdminById;
using Pharamcy.Domain.Identity;

namespace Pharamcy.Application.Common.Mapping
{
    public class SystemAdminMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ApplicationUser, GetAllSystemAdminOrAdminDto>();
            config.NewConfig<ApplicationUser, GetSystemAdminOrAdminByIdDto>();

        }
    }
}
