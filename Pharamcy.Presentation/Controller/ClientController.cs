using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    [Authorize]
    public class ClientController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ClientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet("{pharmacyId}")]
        //public async Task<ActionResult<GetAllClientQeryDto>>Get(int pharmacyId)
        //{

        //}
    }
}
