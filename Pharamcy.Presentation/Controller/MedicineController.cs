using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Medicines.Commands.CreateFromPurchaseInvoice;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineByName;

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
        public async Task<ActionResult<string>> CreateMedicineFromSupplyInovice([FromBody] CreateFromPurchaseInoviceCommand command)
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
    }
}
