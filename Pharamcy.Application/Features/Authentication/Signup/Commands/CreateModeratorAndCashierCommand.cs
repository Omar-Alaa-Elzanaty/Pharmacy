using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Authentication.Signup.Commands
{
    public record CreateModeratorAndCashierCommand:IRequest<Response>
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Role { get; set; }
        public int PharmacyId { get; set; }
    };
    internal class CreateModeratorAndCashierCommandHandler : IRequestHandler<CreateModeratorAndCashierCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateModeratorAndCashierCommand> _localizer;

        public CreateModeratorAndCashierCommandHandler(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IStringLocalizer<CreateModeratorAndCashierCommand> localizer)
        {
            _userManager = userManager;
            _mapper = mapper;
            _localizer = localizer;
        }
        public async Task<Response> Handle(CreateModeratorAndCashierCommand command, CancellationToken cancellationToken)
        {
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(command.UserId)??new ApplicationUser());

            if (!roles.Any(i => i == Roles.Admin) && command.Role == Roles.Moderator)
                return await Response.FailureAsync(_localizer["InvalidOperation"]);
            
            if (command.Role != Roles.SystemAdmin || command.Role != Roles.Admin)
            {
                return await Response.FailureAsync(_localizer["InvalidOperation"]);
            }
            if (await _userManager.FindByEmailAsync(command.Email) != null)
                return new Response() { IsSuccess = false, Message = _localizer["EmailExist"] };

            if (await _userManager.FindByNameAsync(command.UserName) != null)
                return new Response { IsSuccess = false, Message = _localizer["NameExist"] };

            var user = _mapper.Map<ApplicationUser>(command);

            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += error + " , ";
                }
                return new Response() { IsSuccess = false, Message = errors };
            }
            await _userManager.AddToRoleAsync(user, command.Role);
           
                await _userManager.AddClaimAsync(user, new Claim(CommonConsts.PharmacyId, $"{command.PharmacyId}"));
            
            return new Response() { IsSuccess = true, Data = user.Id };
        }


    }

}
