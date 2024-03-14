using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.DTOs;
using Pharamcy.Application.Interfaces.Email;
using Pharamcy.Domain.Identity;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Authentication.ForgetPassword.Commands
{
    public record ForgetPasswordCommand:IRequest<Response>
    {
        public string Email { get; set; }
    }
    internal class ForgetPasswordCommandHandler : IRequestHandler<ForgetPasswordCommand, Response> 
    {
        private readonly IEmailSerivce _emailSerivce;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IStringLocalizer<ForgetPasswordCommandHandler> _localization;
        private readonly IValidator<ForgetPasswordCommand> _validator;
        private readonly IMemoryCache _memoryCache;
        public ForgetPasswordCommandHandler(
            IEmailSerivce emailSerivce,
            UserManager<ApplicationUser> userManager,
            IMemoryCache memoryCache,
            IStringLocalizer<ForgetPasswordCommandHandler> localization)
        {
            _emailSerivce = emailSerivce;
            _userManager = userManager;
            _memoryCache = memoryCache;
            _localization = localization;
        }

        public async Task<Response> Handle(ForgetPasswordCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if(!validationResult.IsValid)
            {
                return await Response.FailureAsync(validationResult.Errors.First().ErrorMessage);
            }

            var user = await _userManager.FindByEmailAsync(command.Email);

            if(user is null)
            {
                return await Response.FailureAsync(_localization["EmailNotExist"].Value);
            }

            var otp = await _memoryCache.GetOrCreateAsync(
                            user.Id.ToString(),
                            cacheEntry =>
                            {
                                cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(10);
                                return Task.FromResult(new Random().Next(1000, 10000));
                            });

            var isSuccess = await _emailSerivce.SendEmailAsync(new EmailRequestDto()
            {
                To = command.Email,
                Subject = "Reset Password OTP Code",
                Body = $"Your Reset OTP is: {otp}"
            });

            if (!isSuccess)
            {
                return await Response.FailureAsync(_localization["SendOtpFail"].Value);
            }

            return await Response.SuccessAsync(_localization["SentOtp"].Value);
        }
    }
}
