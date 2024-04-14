using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Pharamcy.Application.Features.Clients.Commands.Create;
using Pharamcy.Application.Features.Clients.Commands.Delete;
using Pharamcy.Application.Features.Clients.Commands.Update;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("{pharmacyId}")]
        //public async Task<ActionResult<GetAllClientQeryDto>>Get(int pharmacyId)
        //{

        //}

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult<string>>Delete(DeleteClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<int>>Update(UpdateClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
