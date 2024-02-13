using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;
using System.Security.Claims;

namespace Pharamcy.Application.Features.Authentication.Signup.Commands
{
    public record CreateSystemAdminAndAdminCommand : IRequest<Response>
    {

        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Role { get; set; }
    };
    internal class CreateSystemAdminAndAdminCommandHandler : IRequestHandler<CreateSystemAdminAndAdminCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateSystemAdminAndAdminCommand> _localizer;

        public CreateSystemAdminAndAdminCommandHandler(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IStringLocalizer<CreateSystemAdminAndAdminCommand> localizer)
        {
            _userManager = userManager;
            _mapper = mapper;
            _localizer = localizer;
        }
        public async Task<Response> Handle(CreateSystemAdminAndAdminCommand command, CancellationToken cancellationToken)
        {
            var roles = await _userManager.GetRolesAsync(await _userManager.FindByIdAsync(command.UserId) ?? new ApplicationUser());

            if (!roles.Any(i => i == Roles.SystemAdmin) && command.Role == Roles.Admin)
                return await Response.FailureAsync(_localizer["InvalidOperation"]);

            if (command.Role!=Roles.Casher|| command.Role != Roles.Moderator) {
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
            
            return new Response() { IsSuccess = true, Data = user.Id };
        }


    }
}
