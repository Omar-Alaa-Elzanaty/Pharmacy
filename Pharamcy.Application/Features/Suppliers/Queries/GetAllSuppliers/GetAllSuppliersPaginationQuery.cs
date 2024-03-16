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
    public record GetAllSuppliersPaginationQuery():PaginationRequest,IRequest<Response>;
    public record GetAllSuppliersResponse(string Name, double FinancialDues) : IRequest<Response>;

    public class GetAllSuppliersQueryHandler : IRequestHandler<GetAllSuppliersPaginationQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSuppliersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetAllSuppliersPaginationQuery query, CancellationToken cancellationToken)
        {
            var entities = _unitOfWork.Repository<Supplier>().GetAllAsync()
                .Result.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToList().Adapt<List<GetAllSuppliersResponse>>();

            var count=entities.Count(); 

            var suppliers = PaginatedResponse<GetAllSuppliersResponse>.Create(entities,count,query.PageNumber,query.PageSize);


            return await Response.SuccessAsync(suppliers);  
        }
    }
}
