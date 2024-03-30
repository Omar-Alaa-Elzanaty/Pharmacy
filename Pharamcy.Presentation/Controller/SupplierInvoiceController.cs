using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.SupplierPurchases.Commands.SavePurchaseCommand;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetAllSupplierInvoicePagination;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetAllUnClosedPurchaseInvoice;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetNextSupplierInvoiceByPharmacyId;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetPrevioudInvoiceByPharmacyId;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetPurchaseInvoiceByImportInvoiceNumber;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetSupplierInvoiceById;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    // [Authorize]
    public class SupplierInvoiceController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierInvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("UnClosed/{pharmacyId}")]
        public async Task<ActionResult<GetAllUnClosedPurchaseInvoiceQueryDto>> GetAllUnClosed(int pharmacyId)
        {
            return Ok(await _mediator.Send(new GetAllUnClosedPurchaseInvoiceQuery(pharmacyId)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetSupplierInvoiceByIdQueryDto>> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetSupplierInvoiceByIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<string>> SavePurchaseInvoice([FromForm] SavePurchaseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("nextInvoice")]
        public async Task<ActionResult<GetNextInvoiceByPharmacyIdQueryDto>> NextInvoice(GetNextInvoiceByPharmacyIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("previousInvoice")]
        public async Task<ActionResult<GetPreviousInvoiceByPharmacyIdQueryDto>> PreviousInvoice(GetPreviousInvoiceByPharmacyIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getByImportNumber")]
        public async Task<ActionResult<GetPurchaseInvoiceByImportInvoiceNumberQueryDto>> GetByImportNumber(GetPurchaseInvoiceByImportInvoiceNumberQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("getAllByPagination")]
        public async Task<ActionResult<GetAllSupplierInvoicePaginationQueryDto>> GetAllByPagination(GetAllSupplierInvoicePaginationQuery query)
        {
            return Ok(await _mediator.Send(query));
        }


    }
}
