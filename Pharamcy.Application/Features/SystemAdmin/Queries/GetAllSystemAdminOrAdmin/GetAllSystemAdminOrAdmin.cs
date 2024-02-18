using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SystemAdmin.Queries.GetAllSystemAdminAndAdmin
{
    public record GetAllSystemAdminOrAdmin : IRequest<Response>
    {
        public string Role { get; set; }
        public string Id { get; set; }

        public GetAllSystemAdminOrAdmin(string role, string id)
        {
            Role = role;
            Id = id;
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
            IEnumerable<ApplicationUser> entities;
            if (query.Role == SystemRoles.SystemAdmin)
            {
                entities = _userManager.GetUsersInRoleAsync(SystemRoles.SystemAdmin)
                           .Result.Where(x => x.Id != query.Id).ToList();
            }
            else
            {
                entities = _userManager.GetUsersInRoleAsync(SystemRoles.Admin).Result.ToList();

            }

            var systemAdminsAndAdmins = _mapper.Map<List<GetAllSystemAdminOrAdminDto>>(entities);

            return await Response.SuccessAsync(systemAdminsAndAdmins);
        }
    }
}
