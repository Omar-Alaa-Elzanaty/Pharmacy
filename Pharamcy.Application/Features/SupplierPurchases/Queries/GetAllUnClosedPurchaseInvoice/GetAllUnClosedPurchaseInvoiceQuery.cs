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

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetAllUnClosedPurchaseInvoice
{
    public  record GetAllUnClosedPurchaseInvoiceQuery:IRequest<Response>
    {
        public int PharmacyId { get; set; }

        public GetAllUnClosedPurchaseInvoiceQuery(int pharmacyId)
        {
            PharmacyId = pharmacyId;
        }
    }
    internal class GetAllUnClosedPurchaseHandler : IRequestHandler<GetAllUnClosedPurchaseInvoiceQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllUnClosedPurchaseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetAllUnClosedPurchaseInvoiceQuery query, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<PurchaseInvoice>().Entities()
                           .Where(x => !x.IsClosed && x.PharmacyId == query.PharmacyId).Select(x => x.Id).ToListAsync();

            var invoices = entities.Adapt<List<GetAllUnClosedPurchaseInvoiceQueryDto>>();

            return await Response.SuccessAsync(invoices);
        }
    }
}
