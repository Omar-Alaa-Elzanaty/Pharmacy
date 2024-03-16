using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllSupplierByPharamcyId
{
    public record GetAllSupplierByPharamcyIdQuery : PaginationRequest, IRequest<Response>
    {
        public int PharmacyId { get; set; }
    }
    internal class GetAllSupplierByPharamcyIdQueryHandler : IRequestHandler<GetAllSupplierByPharamcyIdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSupplierByPharamcyIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetAllSupplierByPharamcyIdQuery query, CancellationToken cancellationToken)
        {
            var entities = _unitOfWork.Repository<Supplier>()
                                .Entities()
                                .Where(x => x.PharmacyId == query.PharmacyId);

            if (query.KeyWord is not null)
            {
                entities = entities.Where(x => x.Name == query.KeyWord);
            }

            var result = await entities.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize)
                                       .ToListAsync(cancellationToken: cancellationToken);

            var suppliers = result.Adapt<List<GetAllSupplierByPharamcyIdQueryDto>>();

            return await Response.SuccessAsync(suppliers);
        }
    }
}
