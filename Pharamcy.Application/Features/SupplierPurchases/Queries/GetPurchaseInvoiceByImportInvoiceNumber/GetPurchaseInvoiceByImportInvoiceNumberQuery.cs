using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using MediatR;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetPurchaseInvoiceByImportInvoiceNumber
{
    public record GetPurchaseInvoiceByImportInvoiceNumberQuery:IRequest<Response>
    {
        public int PharmacyId { get; set; }
        public string ImportInvoiceNumber { get; set; }
    }

    internal class GetPurchaseInvoiceByImportInvoiceNumberQueryHandler : IRequestHandler<GetPurchaseInvoiceByImportInvoiceNumberQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPurchaseInvoiceByImportInvoiceNumberQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetPurchaseInvoiceByImportInvoiceNumberQuery query, CancellationToken cancellationToken)
        {
            var invoice =  _unitOfWork.Repository<PurchaseInvoice>()
                .GetItemOnAsync(x=>x.ImportInvoiceNumber==query.ImportInvoiceNumber&&x.PharmacyId==query.PharmacyId).Result.Adapt<GetPurchaseInvoiceByImportInvoiceNumberQueryDto>();

           // var invoice = _mapper.Map<>(entities);
            

            return await Response.SuccessAsync(invoice);
        }
    }
}
