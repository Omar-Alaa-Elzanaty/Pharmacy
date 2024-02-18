using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SystemAdmin.Queries.GetAllSystemAdminAndAdmin
{
    public record GetAllSystemAdminOrAdmin:IRequest<Response>
    {
        public string Role { get; set; }

        public GetAllSystemAdminOrAdmin(string role)
        {
            Role = role;
        }
    }
    internal class GetAllSystemAdminAndAdminHandler : IRequestHandler<GetAllSystemAdminOrAdmin, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public GetAllSystemAdminAndAdminHandler(
            IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Response> Handle(GetAllSystemAdminOrAdmin query, CancellationToken cancellationToken)
        {
            IList<ApplicationUser> entities;
            if(query.Role==SystemRoles.SystemAdmin)
            {
                entities = await _userManager.GetUsersInRoleAsync(SystemRoles.SystemAdmin);
            }
            else
            {
                entities = await _userManager.GetUsersInRoleAsync(SystemRoles.Admin);

            }

            var systemAdminsAndAdmins = _mapper.Map<GetAllSystemAdminOrAdminDto>(entities);

            return await Response.SuccessAsync(systemAdminsAndAdmins);
        }
    }
}
