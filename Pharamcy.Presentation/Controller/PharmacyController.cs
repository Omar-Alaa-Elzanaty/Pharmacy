using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Pharmacy.Commands.CreateCommand;
using Pharamcy.Application.Features.Pharmacy.Commands.DeleteByIdCommand;

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
        [HttpDelete]
        public async Task<IActionResult>DeletePharmacy(DeleteByIdCommand command)
        {

            return Ok(_mediator.Send(command)); 
        }
    }
}
