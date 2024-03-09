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

namespace Pharamcy.Application.Features.Company.Queries.GetDeptByCompanyId
{
    public record GetDeptByCompanyIdQuery(int Id) : IRequest<Response>;

    internal class GetDeptByCompanyIdCommandHandler : IRequestHandler<GetDeptByCompanyIdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetDeptByCompanyIdCommandHandler> _localizer;
        public GetDeptByCompanyIdCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<GetDeptByCompanyIdCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Response> Handle(GetDeptByCompanyIdQuery request, CancellationToken cancellationToken)
        {
            var dept = await _unitOfWork.Repository<MedicalCompany>().GetByIdAsync(request.Id);

            return await Response.SuccessAsync(dept, _localizer["Success"]);
        }
    }
}
