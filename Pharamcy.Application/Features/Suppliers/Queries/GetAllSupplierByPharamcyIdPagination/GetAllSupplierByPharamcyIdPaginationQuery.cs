using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllSupplierByPharamcyIdPagination
{
    public record GetAllSupplierByPharamcyIdPaginationQuery : PaginationRequest, IRequest<Response>
    {
        public int PharmacyId { get; set; }
    }
    internal class GetAllSupplierByPharamcyIdQueryHandler : IRequestHandler<GetAllSupplierByPharamcyIdPaginationQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSupplierByPharamcyIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetAllSupplierByPharamcyIdPaginationQuery query, CancellationToken cancellationToken)
        {
            var entities = _unitOfWork.Repository<Supplier>()
                                .Entities()
                                .Where(x => x.PharmacyId == query.PharmacyId);

            if (query.KeyWord is not null)
            {
                entities = entities.Where(x => x.Name.ToLower().Contains(query.KeyWord.ToLower()));
            }

            var result = await entities.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize)
                                       .ToListAsync(cancellationToken: cancellationToken);

            var suppliers = result.Adapt<List<GetAllSupplierByPharamcyIdPaginationQueryDto>>();

            return await Response.SuccessAsync(suppliers);
        }
    }
}
