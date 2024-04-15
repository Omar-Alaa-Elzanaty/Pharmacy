using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Pharamcy.Application.Features.Clients.Commands.Create
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).Length(11);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
