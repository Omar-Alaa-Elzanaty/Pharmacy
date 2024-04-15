using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.MedicalTypes.Queries;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    [Authorize()]
    public class MedicalTypeController:ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MedicalTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllMedicalTypesQueryDto>>Get(GetAllMedicalTypesQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
