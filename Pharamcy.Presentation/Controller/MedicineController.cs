using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Medicines.Commands.CreateFromPurchaseInvoice;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]/[action]")]
    [Authorize()]
    public class MedicineController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MedicineController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult<string>>CreateMedicineFromSupplyInovice(CreateFromPurchaseInoviceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
