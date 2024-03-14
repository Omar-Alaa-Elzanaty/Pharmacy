using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Suppliers.Commands.Create;
using Pharamcy.Application.Features.Suppliers.Queries.GetAllSupplierByPharamcyId;
using Pharamcy.Application.Features.Suppliers.Queries.GetAllSuppliers;
using Pharamcy.Application.Features.Suppliers.Queries.GetDeptBySupplierd;

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

        [HttpGet]
        public async Task<IActionResult> GetSupplierDues(int id)
        {

            return Ok(await _mediator.Send(new GetDeptBySupplierIdQuery() {Id=id,PharmacyId=1 }));
        }
        [HttpGet("getAllByPhamracyId")]
        public async Task<ActionResult<GetAllSuppliersResponse>> GetAllSuppliersbyPharmacyId(int id)
        {
            return Ok(await _mediator.Send(new GetAllSupplierByPharamcyIdQuery(id)));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateSupplierCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}
