using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Company.Queries.GetDeptByCompanyId;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    internal class CompanyController:ApiControllerBase
    {
        private readonly IMediator mediator;

        public CompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyDues(int id)
        {

            return Ok(await mediator.Send(new GetDeptByCompanyIdQuery(id)));
        }
    }
}
