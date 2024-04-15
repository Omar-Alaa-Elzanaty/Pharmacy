using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Pharamcy.Application.Features.Clients.Commands.Update
{
    public class UpdateClientCommandValidator:AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(x => x.PhoneNumber).Length(11);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
