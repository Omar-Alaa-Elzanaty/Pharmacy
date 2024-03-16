using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Pharamcy.Application.Features.Medicines.Commands.CreateFromPurchaseInvoice
{
    public class CreateFromPurchaseInoviceCommandValidator:AbstractValidator<CreateFromPurchaseInoviceCommand>
    {
        public CreateFromPurchaseInoviceCommandValidator()
        {
            RuleFor(x => x.PurchasePrice).NotEmpty().GreaterThan(0);
            RuleFor(x => x.PharmacyId).NotEmpty();
            RuleFor(x => x.EnglishName).NotEmpty().MaximumLength(20);
            RuleFor(x=>x.ArabicName).NotEmpty().MaximumLength(20);
            RuleFor(x=>x.Type).NotEmpty().MaximumLength(25);
        }
    }
}
