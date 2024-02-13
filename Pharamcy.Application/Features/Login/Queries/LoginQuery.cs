using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Pharamcy.Application.Interfaces.Auth;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Login.Queries
{
    public record LoginQuery:IRequest<Response>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthServices _authServices;

        public LoginQueryHandler(
            UserManager<ApplicationUser> userManager,
            IAuthServices authServices)
        {
            _userManager = userManager;
            _authServices = authServices;
        }

        public async Task<Response> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(query.UserName);

            if (user is null || await _userManager.CheckPasswordAsync(user, query.Password)) 
            {
                return await Response.FailureAsync("Invalid username or password.");
            }
            var userRole = _userManager.GetRolesAsync(user).Result.SingleOrDefault();

            var token = _authServices.GenerateToken(user, userRole!);

            var response = new GetLoginDto()
            {
                Id = user.Id,
                UserName = query.UserName,
                Token = token,
                Role = userRole!
            };

            return await Response.SuccessAsync(response);
        }
    }
}
