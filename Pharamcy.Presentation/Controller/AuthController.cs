using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Authentication.Login.Queries;
using Pharamcy.Application.Features.Authentication.Signup.Commands;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ApiController
    {
        private IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Login(LoginQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [HttpPost]
        public async Task<IActionResult> CreateSystemAdminAndAdmin(CreateSystemAdminAndAdminCommand command)
        {
            return Ok(await _mediator.Send(command));

        }
        [HttpPost]
        public async Task<IActionResult> CreateModeratorAndCashier(CreateModeratorAndCashierCommand command)
        {
            return Ok(await _mediator.Send(command));

        }
    }
}
