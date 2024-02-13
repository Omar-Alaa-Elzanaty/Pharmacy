using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Login.Queries;
using Pharamcy.Application.Features.Pharmacy.Commands.CreateCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
