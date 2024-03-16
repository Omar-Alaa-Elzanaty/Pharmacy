using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Authentication.VerifiyOtp
{
    public record VerifiyOtpCommand:IRequest<Response>
    {
        public string Email { get; set; }
        public int Otp { get; set; }
    }

    internal class VerifiyPasswordCommandHandler : IRequestHandler<VerifiyOtpCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMemoryCache _memoryCache;
        private readonly IStringLocalizer<VerifiyPasswordCommandHandler> _localization;
        public VerifiyPasswordCommandHandler(
            UserManager<ApplicationUser> userManager,
            IMemoryCache memoryCache,
            IStringLocalizer<VerifiyPasswordCommandHandler> localization)
        {
            _userManager = userManager;
            _memoryCache = memoryCache;
            _localization = localization;
        }

        public async Task<Response> Handle(VerifiyOtpCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Email);

            if (user is null)
            {
                return await Response.FailureAsync(_localization["EmailNotExist"].Value);
            }

            var otp = _memoryCache.Get(user.Id) as int?;

            if (otp is null || otp != command.Otp)
            {
                return await Response.FailureAsync(_localization["InCorrectOtp"].Value);
            }

            _memoryCache.Remove(user.Id);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);

            return await Response.SuccessAsync(token);

        }
    }
}
