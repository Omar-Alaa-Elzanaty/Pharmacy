using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Deliveries.Commands.Create;
using Pharamcy.Application.Features.Deliveries.Commands.Delete;
using Pharamcy.Application.Features.Deliveries.Commands.Update;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    public class DeliveryController:ApiControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody]CreateDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete([FromBody]DeleteDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<string>> Update([FromBody]UpdateDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
