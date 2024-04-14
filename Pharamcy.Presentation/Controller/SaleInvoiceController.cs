using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.SaleInvoice.Commands.SaveSaleInvoceCommand;
using System.Security.Claims;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SaleInvoiceController: ApiControllerBase
    {

        private IMediator _mediator;

        public SaleInvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(SaveSaleInvoceCommand command)
        {
            command.UserId = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)!.Value;
            return Ok(await _mediator.Send(command));

        }
    }
}
