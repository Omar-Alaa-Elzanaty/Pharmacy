using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Pharmacy.Commands.Create
{
    public class CreatePharmacyCommandValidator : AbstractValidator<CreatePharmacyCommand>
    {
        public CreatePharmacyCommandValidator()
        {
            RuleFor(x => x.EnglishHeader).NotEmpty().MaximumLength(30);
            RuleFor(x=>x.EnglishFooter).NotEmpty().MaximumLength(30);
            RuleFor(x=>x.PhoneNumber).NotEmpty().MaximumLength(14);
            RuleFor(x=>x.PhoneNumber).NotNull().MaximumLength(14);
            RuleFor(x=>x.Address).NotEmpty().MaximumLength(30);
            RuleFor(x=>x.ArabicFooter).NotEmpty().MaximumLength(30);
            RuleFor(x=>x.ArabicHeader).NotEmpty().MaximumLength(30);
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(30);
            RuleFor(x=>x.OwnerId).NotEmpty();
        }
    }
}
