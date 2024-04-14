using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Medicines.Commands.CreateFromPurchaseInvoice;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCode;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCodeSaleInvoice;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineByName;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineForSalesInvoiceByName;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    //[Authorize()]
    public class MedicineController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("createFromPurchaseInvoice")]
        public async Task<IActionResult> CreateMedicineFromSupplyInovice( [FromBody]CreateFromPurchaseInoviceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("BarCode")]
        public async Task<ActionResult<GetMedicineByBarCodeQueryDto>> GetByBarCode(GetMedicineByBarCodeQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpGet("getByName")]
        public async Task<ActionResult<GetMedicineByNameQueryDto>> GetByName(GetMedicineByNameQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("GetByNameSalesInvoice")]
        public async Task<ActionResult<GetMedicineForSalesInvoiceByNameQueryDto>>GetByName([FromBody]GetMedicineForSalesInvoiceByNameQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("GetByBarCodeSalesInvoice")]
        public async Task<ActionResult<GetMedicineByBarCodeSaleInvoiceQueryDto>> GetByBarCode([FromBody] GetMedicineByBarCodeSaleInvoiceQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
