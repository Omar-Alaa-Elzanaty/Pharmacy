﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetNextSupplierInvoiceByPharmacyId
{
    public record GetNextInvoiceByPharmacyIdQuery:IRequest<Response>
    {
        public int PharamcyId { get; set; }
        public int Order { get; set; }
    }
    internal class GetNextSupplierInvoiceByPharmacyIdQueryHandler : IRequestHandler<GetNextInvoiceByPharmacyIdQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetNextSupplierInvoiceByPharmacyIdQueryHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetNextInvoiceByPharmacyIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<PurchaseInvoice>().Entities().Where(x => x.PharmacyId == query.PharamcyId)
                            .Order().Skip(query.Order - 1).Take(query.Order).FirstOrDefaultAsync();

            var invoice = _mapper.Map<GetNextInvoiceByPharmacyIdQueryDto>(entity);

            return await Response.SuccessAsync(invoice);
        }
    }
}