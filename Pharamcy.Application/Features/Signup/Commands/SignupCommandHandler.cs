using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Features.Pharmacy.Commands.DeleteByIdCommand;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Signup.Commands
{
    public record SignupCommand : IRequest<Response>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Role { get; set; }
    };
    public class SignupCommandHandler : IRequestHandler<SignupCommand, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SignupCommandHandler> _localizer;

        public SignupCommandHandler(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IStringLocalizer<SignupCommandHandler> localizer)
        {
            _userManager = userManager;
            _mapper = mapper;
            _localizer = localizer;
        }
        public async Task<Response> Handle(SignupCommand command, CancellationToken cancellationToken)
        {

            if (await _userManager.FindByEmailAsync(command.Email) != null)
                return new Response() { IsSuccess = false, Message = _localizer["email exist"] };

            if (await _userManager.FindByNameAsync(command.UserName) != null)
                return new Response { IsSuccess = false, Message = _localizer["name exist"] };

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
