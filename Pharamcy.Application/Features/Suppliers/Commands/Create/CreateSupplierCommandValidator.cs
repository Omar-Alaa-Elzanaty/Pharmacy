using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Pharamcy.Application.Features.Suppliers.Commands.Create
{
    public class CreateSupplierCommandValidator:AbstractValidator<CreateSupplierCommand>
    {
        public CreateSupplierCommandValidator()
        {
            
        }
    }
}
