using Mapster;
using MediatR;
using Pharamcy.Application.Extensions;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SaleInvoice.Queries.GetSaleInvoiceByIdPagination
{
    public record GetSaleInvoiceByIdPaginationQuery : IRequest<PaginatedResponse<GetSaleInvoiceByIdPaginationQueryDto>>
    {

        public int PharmacyId { get; set; }
        public int PageNumber { get; set; }
        public int? ClientId { get; set; }
        public int PageSize { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Id { get; set; }
    }
    public class GetSaleInvoiceByIdPaginationQueryHandler : IRequestHandler<GetSaleInvoiceByIdPaginationQuery, PaginatedResponse<GetSaleInvoiceByIdPaginationQueryDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetSaleInvoiceByIdPaginationQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PaginatedResponse<GetSaleInvoiceByIdPaginationQueryDto>> Handle(GetSaleInvoiceByIdPaginationQuery query, CancellationToken cancellationToken)
        {

            var entities = _unitOfWork.Repository<SalesInvoice>()
                .Entities().Where(x => x.PharmacyId == query.PharmacyId && x.Id.ToString().Contains(query.Id.ToString()));

            if (query.ClientId is not null)
            {
                entities = entities.Where(i => i.ClientId == query.ClientId);
            }

            if (query.StartDate is not null && query.EndDate is not null)
            {
                entities = entities.Where(x => x.CreatedDate >= query.StartDate && x.CreatedDate <= query.EndDate);
            }
            else if (query.StartDate is not null)
            {
                entities = entities.Where(x => x.CreatedDate >= query.StartDate);
            }
            else if (query.EndDate is not null)
            {
                entities = entities.Where(x => x.CreatedDate <= query.EndDate);
            }

            entities.OrderBy(x => x.CreatedDate);
            return await entities.ProjectToType<GetSaleInvoiceByIdPaginationQueryDto>()
                                        .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}