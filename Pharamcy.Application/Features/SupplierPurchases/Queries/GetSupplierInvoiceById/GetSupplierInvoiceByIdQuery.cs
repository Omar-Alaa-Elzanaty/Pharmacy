using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetSupplierInvoiceById
{
    public record GetSupplierInvoiceByIdQuery:IRequest<Response>
    {
        public int Id { get; set; }
        public GetSupplierInvoiceByIdQuery(int id)
        {
            Id = id;
        }
    }
    internal class GetSupplierInvoiceByIdQueryHandler : IRequestHandler<GetSupplierInvoiceByIdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetSupplierInvoiceByIdQueryHandler> _localization;

        public GetSupplierInvoiceByIdQueryHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<GetSupplierInvoiceByIdQueryHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<Response> Handle(GetSupplierInvoiceByIdQuery command, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<PurchaseInvoice>().GetByIdAsync(command.Id);

            if (entity is null) 
            {
                return await Response.FailureAsync(_localization["InvoiceNotFound"].Value);
            }

            var invoice = entity.Adapt<GetSupplierInvoiceByIdQueryDto>();

            return await Response.SuccessAsync(invoice);
        }
    }
}
