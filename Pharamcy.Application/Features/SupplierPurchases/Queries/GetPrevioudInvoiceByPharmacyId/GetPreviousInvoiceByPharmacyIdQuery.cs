using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetPrevioudInvoiceByPharmacyId
{
    public record GetPreviousInvoiceByPharmacyIdQuery:IRequest<Response>
    {
        public int PharmacyId { get; set; }
        public int Order { get; set; }
        public bool IsLast { get; set;  }
    }
    internal class GetNextInvoiceByPharmacyIdQueryHandler : IRequestHandler<GetPreviousInvoiceByPharmacyIdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNextInvoiceByPharmacyIdQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetPreviousInvoiceByPharmacyIdQuery query, CancellationToken cancellationToken)
        {
            PurchaseInvoice? entity;
            if (query.IsLast)
            {
                entity = await _unitOfWork.Repository<PurchaseInvoice>().Entities().Where(x => x.PharmacyId == query.PharmacyId)
                            .LastAsync();
            }
            else
            {
                entity = await _unitOfWork.Repository<PurchaseInvoice>().Entities().Where(x => x.PharmacyId == query.PharmacyId)
                         .Skip(query.Order - 1).Take(1).FirstOrDefaultAsync();
            }

            var invoice = _mapper.Map<GetPreviousInvoiceByPharmacyIdQueryDto>(entity);

            return await Response.SuccessAsync(entity);
        }
    }
}
