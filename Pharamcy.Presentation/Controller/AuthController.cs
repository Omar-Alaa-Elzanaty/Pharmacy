using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Authentication.Login.Queries;
using Pharamcy.Application.Features.Authentication.Signup.Commands.CreateModeratorAndCashierCommandValidator;
using Pharamcy.Application.Features.Authentication.Signup.Commands.CreateSystemAdminAndAdmin;
using Pharamcy.Shared;
using System.Security.Claims;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            return Ok(await _mediator.Send(query));
            
        }
        [HttpPost]
        [Authorize(Roles = SystemRoles.SystemAdmin)]
        public async Task<ActionResult<int>> CreateSystemAdminAndAdmin([FromForm]CreateSystemAdminAndAdminCommand command)
        {
            return Ok(await _mediator.Send(command));

        }
        [HttpPost]
        [Authorize(Roles = $"{SystemRoles.Admin},{SystemRoles.Moderator}")]
        public async Task<IActionResult> CreateModeratorAndCashier([FromForm] CreateModeratorAndCashierCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
