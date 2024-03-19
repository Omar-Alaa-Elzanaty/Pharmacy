using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Suppliers.Commands.Create;
using Pharamcy.Application.Features.Suppliers.Queries.GetAllSupplierByPharamcyIdPagination;
using Pharamcy.Application.Features.Suppliers.Queries.GetAllSupplierByPharamcyIdPagination;
using Pharamcy.Application.Features.Suppliers.Queries.GetAllDeptsBySupplierId;
using Pharamcy.Application.Features.Suppliers.Queries.GetAllSuppliersByPharmacyId;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("getSupplierDue")]
        public async Task<IActionResult> GetSupplierDues([FromQuery]GetAllDeptsBySupplierdQuery query)
        {

            return Ok(await _mediator.Send(query));
        }
        [HttpGet("getAllByPhamracyIdPagination")]
        public async Task<ActionResult<GetAllSupplierByPharamcyIdPaginationQueryDto>> GetAllSuppliersbyPharmacyIdPAgination([FromQuery]GetAllSupplierByPharamcyIdPaginationQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("getAllByPhamracyId/{id}")]
        public async Task<ActionResult<GetAllSuppliersByPharmacyIdQueryDto>> GetAllSuppliersbyPharmacyId(int id)
        {
            return Ok(await _mediator.Send(new GetAllSuppliersByPharmacyIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSupplierCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
