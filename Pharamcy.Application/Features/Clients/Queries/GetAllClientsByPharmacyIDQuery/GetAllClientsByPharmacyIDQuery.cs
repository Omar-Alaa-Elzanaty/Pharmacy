using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Clients.Queries.GetAllClientsByPharmacyIDQuery
{
	public class GetAllClientsByPharmacyIDQuery : IRequest<Response>
	{
		public int PharmacyID { get; set; }
	}
	internal class GetAllClientsByPharmacyIDQueryHandler : IRequestHandler<GetAllClientsByPharmacyIDQuery, Response>
	{
		private readonly IUnitOfWork _unitofwork;
		private readonly IStringLocalizer<GetAllClientsByPharmacyIDQueryHandler> _localizer;

		public GetAllClientsByPharmacyIDQueryHandler(IUnitOfWork unitofwork, IStringLocalizer<GetAllClientsByPharmacyIDQueryHandler> localizer)
		{
			_unitofwork = unitofwork;
			_localizer = localizer;
		}

		public async Task<Response> Handle(GetAllClientsByPharmacyIDQuery query, CancellationToken cancellationToken)
		{
			var clients = await _unitofwork.Repository<Client>().GetAllAsync(oj => oj.Id == query.PharmacyID);
			return await Response.SuccessAsync(clients.Adapt<IEnumerable<GetAllClientsByPharmacyIDQueryDto>>(), _localizer["Success"].Value);
		}
	}
}
