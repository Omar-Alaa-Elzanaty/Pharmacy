using System.Security.Claims;
using FluentValidation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Authentication.Signup.Commands.CreateModeratorAndCashierCommandValidator
{
    public record CreateModeratorAndCashierCommand : IRequest<Response>
    {
        public string UserName { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
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
        private readonly IValidator<CreateModeratorAndCashierCommand> _validator;

        public CreateModeratorAndCashierCommandHandler(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IStringLocalizer<CreateModeratorAndCashierCommand> localizer,
            IValidator<CreateModeratorAndCashierCommand> validator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _localizer = localizer;
            _validator = validator;
        }
        public async Task<Response> Handle(CreateModeratorAndCashierCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

                return await Response.FailureAsync(errors, _localizer["InvalidRequest"].Value);
            }

            var entity = await _userManager.FindByIdAsync(command.UserId);

            if (entity is null)
            {
                return await Response.FailureAsync(_localizer["UnAuthorized"].Value);
            }

            var role = _userManager.GetRolesAsync(entity).Result.FirstOrDefault();

            if (role == SystemRoles.Moderator && command.Role == SystemRoles.Moderator)
            {
                return await Response.FailureAsync(_localizer["UnAuthorized"]);
            }

            if (command.Role == SystemRoles.Admin && command.Role == SystemRoles.Admin)
            {
                return await Response.FailureAsync(_localizer["UnAuthorized"]);
            }

            if (await _userManager.FindByEmailAsync(command.Email) != null)
            {
                return await Response.FailureAsync(_localizer["EmailExist"]);
            }

            if (await _userManager.FindByNameAsync(command.UserName) != null)
            {
                return new Response { IsSuccess = false, Message = _localizer["NameExist"] };
            }

            var user = _mapper.Map<ApplicationUser>(command);

            var result = await _userManager.CreateAsync(user,command.Password);
           

            if (!result.Succeeded)
            {
                return await Response.FailureAsync(result.Errors, _localizer["Failed"]);
            }

            await _userManager.AddToRoleAsync(user, command.Role);

            await _userManager.AddClaimAsync(user, new Claim(CommonConsts.PharmacyId, $"{command.PharmacyId}"));

            return await Response.SuccessAsync(user.Id, _localizer["Success"]);
        }


    }

}
