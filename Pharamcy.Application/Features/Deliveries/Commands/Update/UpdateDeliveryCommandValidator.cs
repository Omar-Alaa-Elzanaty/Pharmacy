using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Pharamcy.Application.Features.Deliveries.Commands.Update
{
    internal class UpdateDeliveryCommandValidator : AbstractValidator<UpdateDeliveryCommand>
    {
        public UpdateDeliveryCommandValidator()
        {
        }
    }
}
