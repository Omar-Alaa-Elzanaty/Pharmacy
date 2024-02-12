using Microsoft.AspNetCore.Identity;
using Pharamcy.Application.Interfaces.Auth;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Infrastructure.Services.Auth
{
    public class Authentication : IAuthServices
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public Authentication(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<Response> SignUp()
        {
            throw new NotImplementedException();
        }
    }
}
