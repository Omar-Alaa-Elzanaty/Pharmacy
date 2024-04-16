using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Clients.Commands.Create;
using Pharamcy.Application.Features.Clients.Commands.Delete;
using Pharamcy.Application.Features.Clients.Commands.Update;
using Pharamcy.Application.Features.Clients.Queries.GetAllClientsByPharmacyIDQuery;

namespace Pharamcy.Presentation.Controller
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ClientController:ApiControllerBase
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
        public async Task<ActionResult<int>> Create([FromBody]CreateClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete([FromBody] DeleteClientCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<int>> Update([FromBody]UpdateClientCommand command)
        {

            return Ok(await _mediator.Send(command));
        }
		[HttpGet]
		public async Task<IActionResult> GetAll(int id)
        {
			return Ok(await _mediator.Send(new GetAllClientsByPharmacyIDQuery { PharmacyID=id}));
        }
    }
}
