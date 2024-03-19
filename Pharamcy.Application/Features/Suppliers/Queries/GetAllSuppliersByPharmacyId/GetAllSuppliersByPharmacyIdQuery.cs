using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllSuppliersByPharmacyId
{
    public class GetAllSuppliersByPharmacyIdQuery:IRequest<Response>
    {
        public GetAllSuppliersByPharmacyIdQuery(int pharmacyId)
        {
            PharmacyId = pharmacyId;
        }

        public int PharmacyId { get; set; }
    }


    public class GetAllSuppliersByPharmacyIdQueryHandler : IRequestHandler<GetAllSuppliersByPharmacyIdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetAllSuppliersByPharmacyIdQueryHandler> _localizer;

        public GetAllSuppliersByPharmacyIdQueryHandler(IUnitOfWork unitOfWork, IStringLocalizer<GetAllSuppliersByPharmacyIdQueryHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Response> Handle(GetAllSuppliersByPharmacyIdQuery query, CancellationToken cancellationToken)
        {
           var Suppliers= _unitOfWork.Repository<Supplier>().GetAllAsync(i=>i.PharmacyId==query.PharmacyId).Result?.Adapt<List<GetAllSuppliersByPharmacyIdQueryDto>>();   
            
         
            
            return await Response.SuccessAsync(Suppliers, _localizer["Success"].Value);  
        }
    }
}
