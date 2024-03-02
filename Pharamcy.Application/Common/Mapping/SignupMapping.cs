using Mapster;
using Pharamcy.Application.Features.Authentication.Signup.Commands.CreateSystemAdminAndAdmin;
using Pharamcy.Domain.Identity;

namespace Pharamcy.Application.Common.Mapping
{
    public class SignupMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<CreateSystemAdminAndAdminCommand, ApplicationUser>();


        }
    }
}
