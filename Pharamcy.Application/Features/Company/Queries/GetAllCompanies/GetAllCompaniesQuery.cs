using Mapster;
using MapsterMapper;
using MediatR;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Application.Features.Company.Queries.GetAllCompanies
{
    public record GetAllCompaniesQuery():IRequest<Response>;
    public record GetAllCompaniesResponse(string Name, double FinancialDues) : IRequest<Response>;

    public class GetAllCompaniesQueryHandler : IRequestHandler<GetAllCompaniesQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCompaniesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetAllCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies =await _unitOfWork.Repository<MedicalCompany>().GetAllAsync(i => i);

            
            var response = companies.Adapt<IEnumerable<GetAllCompaniesResponse>>();

            return await Response.SuccessAsync(response);  
        }
    }
}
