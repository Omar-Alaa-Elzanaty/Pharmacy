using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Deliveries.Commands.Create;
using Pharamcy.Application.Features.Deliveries.Commands.Delete;
using Pharamcy.Application.Features.Deliveries.Commands.Update;
using Pharamcy.Application.Features.Deliveries.Queries.GetAllDeliveries;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    public class DeliveryController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{pharamcyId}")]
        public async Task<ActionResult<GetAllDeliveriesByPharmacyIdQueryDto>> Get(int pharamcyId)
        {
            return Ok(await _mediator.Send(new GetAllDeliveriesByPharmacyIdQuery(pharamcyId)));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<ActionResult<string>> Delete([FromBody] DeleteDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<ActionResult<string>> Update([FromBody] UpdateDeliveryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
