using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.SaleInvoice.Commands.SaveSaleInvoceCommand;
using Pharamcy.Application.Features.SaleInvoice.Queries.GetSaleInvoiceByIdPagination;
using System.Security.Claims;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleInvoiceController: ApiControllerBase
    {

        private IMediator _mediator;

        public SaleInvoiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveSaleInvoceCommand command)
        {
            command.UserId = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)!.Value;
            return Ok(await _mediator.Send(command));

        }
        [HttpGet]

        public async Task<IActionResult> SaleInvoiceById(GetSaleInvoiceByIdPaginationQuery query)
        {
            // command.UserId = User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier)!.Value;
            return Ok(await _mediator.Send(query));

        }
    }
}
