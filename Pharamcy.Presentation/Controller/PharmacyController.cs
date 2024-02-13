using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Pharmacy.Commands.CreateCommand;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ApiController
    {
        private IMediator _mediator;

        public PharmacyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddPharmacy(CreatePharmacyCommand command)
        {
            return Ok(_mediator.Send(command));


        }
    }
}
