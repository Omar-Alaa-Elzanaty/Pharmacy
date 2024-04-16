using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;
using System.Security.Claims;

namespace Pharamcy.Application.Features.Clients.Queries.GetAllClientsByPharmacyIDQuery
{
	public class GetAllClientsByPharmacyIDQuery : IRequest<Response>
	{
		public int PharmacyId { get; set; }

        public GetAllClientsByPharmacyIDQuery(int pharmacyId)
        {
            PharmacyId = pharmacyId;
        }
    }
	internal class GetAllClientsByPharmacyIDQueryHandler : IRequestHandler<GetAllClientsByPharmacyIDQuery, Response>
	{
		private readonly IUnitOfWork _unitofwork;
		private readonly IStringLocalizer<GetAllClientsByPharmacyIDQueryHandler> _localizer;
		private readonly IHttpContextAccessor _contextAccessor;

        public GetAllClientsByPharmacyIDQueryHandler(IUnitOfWork unitofwork, IStringLocalizer<GetAllClientsByPharmacyIDQueryHandler> localizer, IHttpContextAccessor contextAccessor)
        {
            _unitofwork = unitofwork;
            _localizer = localizer;
            _contextAccessor = contextAccessor;
        }

        public async Task<Response> Handle(GetAllClientsByPharmacyIDQuery query, CancellationToken cancellationToken)
		{
            var pharmacy = await _unitofwork.Repository<Domain.Models.Pharmacy>().GetItemOnAsync(p => p.Id == query.PharmacyId);
            if (pharmacy == null)
            {
                return await Response.FailureAsync(_localizer["PharmacyNotExist"].Value);
            }
            if (_contextAccessor.HttpContext.User.Claims.FirstOrDefault(i => i.Type == ClaimTypes.NameIdentifier).Value == pharmacy.OwnerId)
            {
                return await Response.FailureAsync("UnAuthonticated");

            }


            var clients = await _unitofwork.Repository<Client>().GetAllAsync(oj => oj.Id == query.PharmacyId);
			return await Response.SuccessAsync(clients.Adapt<IEnumerable<GetAllClientsByPharmacyIDQueryDto>>(), _localizer["Success"].Value);
		}
	}
}
