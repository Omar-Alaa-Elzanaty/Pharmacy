using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Pharamcy.Application.Features.SupplierPurchases.Commands.SavePurchaseCommand
{
    public class SavePurchaseCommandValidator:AbstractValidator<SavePurchaseCommand>
    {
        public SavePurchaseCommandValidator()
        {
            RuleFor(x => x.Paied).NotEmpty();
            RuleFor(x=>x.TotalCost).NotEmpty();
            RuleFor(x=>x.IsClosed).NotEmpty();
            RuleFor(x=>x.ImportInvoiceNumber).NotEmpty();
            RuleFor(x=>x.SupplierId).NotEmpty();
            RuleFor(x=>x.CreatorName).NotEmpty();
            RuleFor(x=>x.DiscountCostPrecent).NotEmpty();
            RuleFor(x=>x.PharmacyId).NotEmpty();
            RuleFor(x=>x.SupplierName).NotEmpty();
            RuleFor(x=>x.TermAmount).NotEmpty();
        }
    }
}
