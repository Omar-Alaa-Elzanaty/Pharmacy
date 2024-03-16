using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Extensions;
using Pharamcy.Domain.Identity;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SystemAdmin.Queries.GetAllSystemAdminOrAdminPagination
{
    public record GetAllSystemAdminOrAdminPagination :PaginationRequest, IRequest<Response>
    {
        public string Role { get; set; }
    }
    internal class GetAllSystemAdminOrAdminPaginationHandler : IRequestHandler<GetAllSystemAdminOrAdminPagination, Response>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStringLocalizer<GetAllSystemAdminOrAdminPaginationHandler> _localization;
        private readonly IMapper _mapper;

        public GetAllSystemAdminOrAdminPaginationHandler(
            IMapper mapper,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IStringLocalizer<GetAllSystemAdminOrAdminPaginationHandler> localization)
        {
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _localization = localization;
        }

        public async Task<Response> Handle(GetAllSystemAdminOrAdminPagination query, CancellationToken cancellationToken)
        {

            if(!await _roleManager.RoleExistsAsync(query.Role))
            {
                return await Response.FailureAsync(_localization["RoleNotExist"].Value);
            }

            var entities = _userManager.GetUsersInRoleAsync(query.Role).Result.ToHashSet();

            query.PageNumber = query.PageNumber <= 0 ? 2 : query.PageNumber;
            query.PageSize = query.PageSize <= 1 ? 10 : query.PageSize;
            var count = entities.Count();

            var pagination = entities.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToList();

            var users = pagination.Adapt<List<GetAllSystemAdminOrAdminPaginationDto>>();

            var usersInRole = PaginatedResponse<GetAllSystemAdminOrAdminPaginationDto>
                                        .Create(users, count, query.PageNumber, query.PageSize);


            return await Response.SuccessAsync(usersInRole);
        }
    }
}
