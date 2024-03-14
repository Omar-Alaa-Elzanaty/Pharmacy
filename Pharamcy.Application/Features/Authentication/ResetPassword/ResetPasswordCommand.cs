using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Localization;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Authentication.ResetPassword
{
    public record ResetPasswordCommand:IRequest<Response>
    {
        public string Password { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
    }

    internal class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<ResetPasswordCommandHandler> _localization;
        public ResetPasswordCommandHandler(
            UserManager<ApplicationUser> userManager,
            IStringLocalizer<ResetPasswordCommandHandler> localization)
        {
            _userManager = userManager;
            _localization = localization;
        }

        public async Task<Response> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            if(user is null)
            {
                return await Response.FailureAsync(_localization["EmailNotExist"].Value);
            }

            var result = await _userManager.ResetPasswordAsync(user, command.Token, command.Password);

            if (!result.Succeeded)
            {
                return await Response.FailureAsync(result.Errors.First().Description);
            }

            return await Response.SuccessAsync(_localization["SuccessChangePassword"].Value);

        }
    }
}
