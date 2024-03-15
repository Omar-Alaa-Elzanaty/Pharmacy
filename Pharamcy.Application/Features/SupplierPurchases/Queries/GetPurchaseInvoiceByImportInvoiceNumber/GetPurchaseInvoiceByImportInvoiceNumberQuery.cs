using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetPurchaseInvoiceByImportInvoiceNumber
{
    public class GetPurchaseInvoiceByImportInvoiceNumberQuery:IRequest<Response>
    {
        public int PharmacyId { get; set; }
        public string ImportInvoiceNumber { get; set; }
    }
    internal class GetPurchaseInvoiceByImportInvoiceNumberQueryHandler : IRequestHandler<GetPurchaseInvoiceByImportInvoiceNumberQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetPurchaseInvoiceByImportInvoiceNumberQueryHandler> localizer;
        private readonly IMapper _mapper;

        public GetPurchaseInvoiceByImportInvoiceNumberQueryHandler(IUnitOfWork unitOfWork, IStringLocalizer<GetPurchaseInvoiceByImportInvoiceNumberQueryHandler> localizer, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            this.localizer = localizer;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetPurchaseInvoiceByImportInvoiceNumberQuery query, CancellationToken cancellationToken)
        {
            var entity=_unitOfWork.Repository<PurchaseInvoice>().GetItemOnAsync(i=>i.PharmacyId==query.PharmacyId&&i.ImportInvoiceNumber==query.ImportInvoiceNumber);

            var invoice = _mapper.Map<GetPurchaseInvoiceByImportInvoiceNumberQueryDto>(entity); 

            return await Response.SuccessAsync(localizer["Success"]);    
        }
    }
}
