using FluentValidation;

namespace Pharamcy.Application.Features.Authentication.Signup.Commands.CreateSystemAdminAndAdmin
{
    public class CreateSystemAdminAndAdminCommandValidator : AbstractValidator<CreateSystemAdminAndAdminCommand>
    {
        public CreateSystemAdminAndAdminCommandValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.NationalId).Length(14);
            RuleFor(x => x.FirstName).MaximumLength(20);
            RuleFor(x => x.LastName).MaximumLength(20);
            RuleFor(x => x.PhoneNumber).MaximumLength(12);
            RuleFor(x => x.UserName).MaximumLength(20);
        }
    }
}
