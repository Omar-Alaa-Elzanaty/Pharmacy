using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Suppliers.Queries.GetDeptBySupplierd
{
    public record GetDeptBySupplierIdQuery: IRequest<Response>
    {
        public int Id { get; set; }
        public int PharmacyId { get; set; }
    }

    internal class GetDeptBySupplierIdQueryHandler : IRequestHandler<GetDeptBySupplierIdQuery, Response>
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

        public async Task<Response> Handle(GetDeptBySupplierIdQuery query, CancellationToken cancellationToken)
        {
            var dept = await _unitOfWork.Repository<Supplier>().GetAllAsync(x => x.PharmacyId == query.PharmacyId && x.Id == query.Id);

            return await Response.SuccessAsync(dept.Select(i=>i.Name), _localizer["Success"]);
        }
    }
}
