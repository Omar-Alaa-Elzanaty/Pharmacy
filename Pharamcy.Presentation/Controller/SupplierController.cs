﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pharamcy.Application.Features.Suppliers.Queries.GetAllSupplierByPharamcyId;
using Pharamcy.Application.Features.Suppliers.Queries.GetAllSuppliers;
using Pharamcy.Application.Features.Suppliers.Queries.GetDeptBySupplierd;

namespace Pharamcy.Presentation.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    internal class SupplierController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public SupplierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSupplierDues(GetDeptBySupplierIdQuery query)
        {

            return Ok(await _mediator.Send(query));
        }
        [HttpGet("getAllByPhamracyId")]
        public async Task<ActionResult<GetAllSuppliersResponse>> GetAllSuppliersbyPharmacyId(GetAllSupplierByPharamcyIdQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

    }
}
