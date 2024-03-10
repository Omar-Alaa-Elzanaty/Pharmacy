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

namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllSuppliers
{
    public record GetAllSuppliersQuery():IRequest<Response>;
    public record GetAllSuppliersResponse(string Name, double FinancialDues) : IRequest<Response>;

    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSuppliersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var companies =await _unitOfWork.Repository<SystemMedicalCompany>().GetAllAsync();

            
            var response = companies.Adapt<IEnumerable<GetAllSuppliersResponse>>();

            return await Response.SuccessAsync(response);  
        }
    }
}
