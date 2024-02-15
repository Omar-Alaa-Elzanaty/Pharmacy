using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;
using System.Net.WebSockets;
using System.Security.Claims;

namespace Pharamcy.Application.Features.Authentication.Signup.Commands.CreateSystemAdminAndAdmin
{
    public record CreateSystemAdminAndAdminCommand : IRequest<Response>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Role { get; set; }
    };
    internal class CreateSystemAdminAndAdminCommandHandler : IRequestHandler<CreateSystemAdminAndAdminCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreateSystemAdminAndAdminCommand> _localizer;
        private readonly IValidator<CreateSystemAdminAndAdminCommand> _validator;

        public CreateSystemAdminAndAdminCommandHandler(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IStringLocalizer<CreateSystemAdminAndAdminCommand> localizer,
            IValidator<CreateSystemAdminAndAdminCommand> validator,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _localizer = localizer;
            _validator = validator;
            _roleManager = roleManager;
        }
        public async Task<Response> Handle(CreateSystemAdminAndAdminCommand command, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(command);

            if(!validationResult.IsValid) 
            {
                var errrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                return await Response.FailureAsync(errrors, _localizer["InvalidRequest"]);
            }
            
            var roleFound = await _roleManager.RoleExistsAsync(command.Role);

            if (!roleFound)
            {
                return await Response.FailureAsync(_localizer["InvalidRequest"]);
            }

            if (command.Role == SystemRoles.Cashier || command.Role == SystemRoles.Moderator)
            {
                return await Response.FailureAsync(_localizer["UnAuthorized"]);
            }

            if (await _userManager.FindByEmailAsync(command.Email) is not null)
            {
                return await Response.FailureAsync(_localizer["EmailExist"]);
            }

            if (await _userManager.FindByNameAsync(command.UserName) != null)
            {
                return await Response.FailureAsync(_localizer["NameExist"]);
            }

            var user = _mapper.Map<ApplicationUser>(command);

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                return await Response.FailureAsync(result.Errors, _localizer["Failed"]);
            }

            await _userManager.AddToRoleAsync(user, command.Role);

            return await Response.SuccessAsync(user.Id, _localizer["Success"].Value);
        }


    }
}
