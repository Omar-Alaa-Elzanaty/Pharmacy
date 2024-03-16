using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllDeptsBySupplierId
{
    public record GetAllDeptsBySupplierdQuery : IRequest<Response>
    {
        public int SupplierId { get; set; }
        public int PharmacyId { get; set; }
    }

    internal class GetDeptBySupplierIdQueryHandler : IRequestHandler<GetAllDeptsBySupplierdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetDeptBySupplierIdQueryHandler> _localizer;
        public GetDeptBySupplierIdQueryHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<GetDeptBySupplierIdQueryHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Response> Handle(GetAllDeptsBySupplierdQuery query, CancellationToken cancellationToken)
        {
            var entity = _unitOfWork.Repository<Supplier>().Entities()
                        .Where(x => x.Id == query.SupplierId && x.PharmacyId == query.PharmacyId);

            var depts = entity.Adapt<GetAllDeptsBySupplierIdQueryDto>();

            return await Response.SuccessAsync(depts, _localizer["Success"]);
        }
    }
}
