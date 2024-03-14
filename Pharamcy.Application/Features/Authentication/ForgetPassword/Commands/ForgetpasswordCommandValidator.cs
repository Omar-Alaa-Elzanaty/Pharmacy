using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Pharamcy.Application.Features.Authentication.ForgetPassword.Commands
{
    public class ForgetpasswordCommandValidator:AbstractValidator<ForgetPasswordCommand>
    {
        public ForgetpasswordCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
