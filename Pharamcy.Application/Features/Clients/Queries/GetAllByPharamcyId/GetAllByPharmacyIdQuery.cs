using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Clients.Queries.GetAllByPharamcyId
{
    public record GetAllByPharmacyIdQuery:IRequest<Response>
    {
        public int PharmacyId { get; set; }

        public GetAllByPharmacyIdQuery(int pharmacyId)
        {
            PharmacyId = pharmacyId;
        }
    }

    internal class GetAllByPharmacyIdQueryHandler : IRequestHandler<GetAllByPharmacyIdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllByPharmacyIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<Response> Handle(GetAllByPharmacyIdQuery query, CancellationToken cancellationToken)
        {
            //var clients=_unitOfWork.Repository<Client>().Entities()
            //    .Where(x=>x)
            //TODO: 
            throw new NotImplementedException();
        }
    }
}
