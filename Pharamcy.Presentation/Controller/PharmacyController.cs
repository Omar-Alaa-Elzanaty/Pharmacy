using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Pharmacy.Commands.Create;
using Pharamcy.Application.Features.Pharmacy.Commands.DeleteById;
using Pharamcy.Application.Features.Pharmacy.Queries.GetAll;
using Pharamcy.Shared;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = SystemRoles.Admin)]
    public class PharmacyController : ApiControllerBase
    {
        private IMediator _mediator;

        public PharmacyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]

        public async Task<IActionResult> AddPharmacy([FromForm] CreatePharmacyCommand command)
        {
            return Ok(await _mediator.Send(command));


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacy(int id)
        {

            return Ok(await _mediator.Send(new DeleteByIdCommand(id)));
        }
        [HttpGet("getAllByOwner/{ownerId}")]
        public async Task<IActionResult> GetPharmacy(string ownerId)
        {

            return Ok(await _mediator.Send(new GetAllPharmacyQuery(ownerId)));
        }

    }
}
