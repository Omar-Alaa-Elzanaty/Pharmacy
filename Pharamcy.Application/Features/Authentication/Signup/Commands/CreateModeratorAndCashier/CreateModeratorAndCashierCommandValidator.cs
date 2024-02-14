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
            
        }
    }
}
