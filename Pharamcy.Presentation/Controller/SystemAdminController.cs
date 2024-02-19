using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Pharamcy.Application.Features.SystemAdmin.Queries.GetAllSystemAdminAndAdmin;
using Pharamcy.Application.Features.SystemAdmin.Queries.GetSystemAdminOrAdminById;
using Pharamcy.Shared;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles =SystemRoles.SystemAdmin)]
    public class SystemAdminController:ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SystemAdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllSystemAdminOrAdminDto>> GetAll(string id, string role)
        {
            return Ok(await _mediator.Send(new GetAllSystemAdminOrAdmin(role,id)));
        }
        [HttpGet]
        public async Task<ActionResult<GetSystemAdminOrAdminByIdDto>> GetById(string id)
        {
            return Ok(await _mediator.Send(new GetSystemAdminOrAdminByIdQuery(id)));
        }
    }
}
