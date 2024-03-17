using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Extensions;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SupplierPurchases.Queries.GetAllSupplierInvoicePagination
{
    public record GetAllSupplierInvoicePaginationQuery : IRequest<PaginatedResponse<GetAllSupplierInvoicePaginationQueryDto>>
    {
        public int PharmacyId { get; set; }
        public int SupplierId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ImportNumber { get; set; }
    }

    internal class GetAllSupplierInvoicePaginationQueryHandler : IRequestHandler<GetAllSupplierInvoicePaginationQuery, PaginatedResponse<GetAllSupplierInvoicePaginationQueryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetAllSupplierInvoicePaginationQueryHandler(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginatedResponse<GetAllSupplierInvoicePaginationQueryDto>> Handle(GetAllSupplierInvoicePaginationQuery query, CancellationToken cancellationToken)
        {
            var entities = _unitOfWork.Repository<PurchaseInvoice>().Entities().Where(i=>i.SupplierId==query.SupplierId);

            if (query.StartDate is not null && query.EndDate is not null)
            {
                entities = entities.Where(x => x.CreatedDate >= query.StartDate && x.CreatedDate <= query.EndDate);
            }
            else if (query.StartDate is not null)
            {
                entities = entities.Where(x => x.CreatedDate >= query.StartDate);
            }
            else if(query.EndDate is not null) 
            {
                entities = entities.Where(x => x.CreatedDate <= query.EndDate);
            }

            if(query.ImportNumber is not null)
            {
                entities = entities.Where(x => x.ImportInvoiceNumber.Contains(query.ImportNumber));
            }

            return await entities.ProjectToType<GetAllSupplierInvoicePaginationQueryDto>()
                                        .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}
