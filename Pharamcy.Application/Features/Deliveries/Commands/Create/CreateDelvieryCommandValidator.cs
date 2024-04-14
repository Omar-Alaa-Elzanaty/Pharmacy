using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Pharamcy.Application.Features.Deliveries.Commands.Create
{
    public class CreateDelvieryCommandValidator:AbstractValidator<CreateDeliveryCommand>
    {
        public CreateDelvieryCommandValidator()
        {
            
        }
    }
}
