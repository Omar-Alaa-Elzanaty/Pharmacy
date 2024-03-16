using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Pharamcy.Application.Features.Authentication.Signup.Commands.CreateModeratorAndCashierCommandValidator;

namespace Pharamcy.Application.Features.Authentication.Signup.Commands.CreateModeratorAndCashier
{
    public class CreateModeratorAndCashierCommandValidatorValidator:AbstractValidator<CreateModeratorAndCashierCommand>
    {
        public CreateModeratorAndCashierCommandValidatorValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.NationalId).Length(14);
            RuleFor(x => x.FirstName).MaximumLength(20);
            RuleFor(x=>x.LastName).MaximumLength(20);
            RuleFor(x=>x.PhoneNumber).MaximumLength(12);
            RuleFor(x=>x.UserName).MaximumLength(20);
        }
    }
}
