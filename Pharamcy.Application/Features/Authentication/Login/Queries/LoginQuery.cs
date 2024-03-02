using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Pharamcy.Application.Interfaces.Auth;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Identity;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;
using System.Security.Claims;

namespace Pharamcy.Application.Features.Authentication.Login.Queries
{
    public record LoginQuery : IRequest<Response>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    internal class LoginQueryHandler : IRequestHandler<LoginQuery, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthServices _authServices;
        private readonly IStringLocalizer<LoginQueryHandler> _stringLocalizer;
        private readonly IUnitOfWork _unitOfWork;

        public LoginQueryHandler(
            UserManager<ApplicationUser> userManager,
            IAuthServices authServices,
            IStringLocalizer<LoginQueryHandler> stringLocalizer,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _authServices = authServices;
            _stringLocalizer = stringLocalizer;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(query.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, query.Password))
            {
                return await Response.FailureAsync(_stringLocalizer["InvalidLogin"].Value);
            }
            var userRole = _userManager.GetRolesAsync(user).Result.Single();
            var token = _authServices.GenerateToken(user, userRole!);

            Domain.Models.Pharmacy pharmacy;

            var usercliam = _userManager.GetClaimsAsync(user).Result.FirstOrDefault(i => i.Type == CommonConsts.PharmacyId);

            if (usercliam is not null)
            {

                pharmacy = await _unitOfWork.Repository<Domain.Models.Pharmacy>().GetByIdAsync(int.Parse(usercliam.Value));

            }
            else
                pharmacy = new();
            

            var response = new GetLoginDto()
            {
                Id = user.Id,
                UserName = query.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = token,
                Role = userRole,
                ImageUrl = user.ImageUrl,
                PharmacyName = pharmacy.Name ?? ""
            };

            return await Response.SuccessAsync(response);
        }
    }
}
