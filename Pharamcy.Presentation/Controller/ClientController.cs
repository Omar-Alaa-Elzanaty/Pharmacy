using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Clients.Queries.GetAllClientsByPharmacyIDQuery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharamcy.Presentation.Controller
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ClientController:ApiControllerBase
	{
		private IMediator _mediator;

		public ClientController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync(int id)
		{
			return Ok(await _mediator.Send(new GetAllClientsByPharmacyIDQuery { PharmacyID=id}));
		}
	}
}
