using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Suppliers.Queries.GetAllSupplierByPharamcyId
{
    public record GetAllSupplierByPharamcyIdQuery:IRequest<Response>
    {
        public int PharmacyId { get; set; }

        public GetAllSupplierByPharamcyIdQuery(int pharmacyId)
        {
            PharmacyId = pharmacyId;
        }
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
            var entities = await _unitOfWork.Repository<Supplier>()
                                .Entities()
                                .Where(x => x.PharamcyId == query.PharmacyId).ToListAsync();

            var suppliers = entities.Adapt<List<GetAllSupplierByPharamcyIdQueryDto>>();

            return await Response.SuccessAsync(suppliers);
        }
    }
}
