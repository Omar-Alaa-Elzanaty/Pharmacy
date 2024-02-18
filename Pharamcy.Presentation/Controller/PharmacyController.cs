﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Pharmacy.Commands.Create;
using Pharamcy.Application.Features.Pharmacy.Commands.DeleteById;
using Pharamcy.Application.Features.Pharmacy.Queries.GetAll;
using Pharamcy.Shared;

namespace Pharamcy.Presentation.Controller
{
    [Authorize(Roles = SystemRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ApiControllerBase
    {
        private IMediator _mediator;

        public PharmacyController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]

        public async Task<IActionResult> AddPharmacy(CreatePharmacyCommand command)
        {
            return Ok( await _mediator.Send(command));


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePharmacy(int id)
        {

            return Ok(await _mediator.Send(new DeleteByIdCommand(id))); 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPharmacy(string id)
        {

            return Ok(await _mediator.Send(new GetAllPharmacyQuery(id)));
        }
    }
}
