using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Deliveries.Queries.GetAllDeliveries
{
    public record GetAllDeliveriesByPharmacyIdQuery:IRequest<Response>
    {
        public int PharmacyId { get; set; }

        public GetAllDeliveriesByPharmacyIdQuery(int pharmacyId)
        {
            PharmacyId = pharmacyId;
        }
    }

    internal class GetAllDeliveriesByPharmacyIdQueryHandler : IRequestHandler<GetAllDeliveriesByPharmacyIdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllDeliveriesByPharmacyIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetAllDeliveriesByPharmacyIdQuery query, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<Delivery>().Entities()
                .Where(x => x.PharmacyId == query.PharmacyId)
                .ToListAsync();

            var deliveries = entities.Adapt<GetAllDeliveriesByPharmacyIdQueryDto>();

            return await Response.SuccessAsync(deliveries);
        }
    }
}
