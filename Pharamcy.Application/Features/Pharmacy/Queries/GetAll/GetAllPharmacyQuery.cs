using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Features.Pharmacy.Commands.DeleteById;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Pharmacy.Queries.GetAll
{
    public record GetAllPharmacyQuery:IRequest<Response> {
        public string Id { get; set; }

        public GetAllPharmacyQuery(string id)
        {
            Id = id;
        }
    };
    internal class GetAllPharmacyQueryHandler : IRequestHandler<GetAllPharmacyQuery, Response>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<DeleteByIdCommandHandler> _localizer;

        public GetAllPharmacyQueryHandler(IUnitOfWork unitofWork, IMapper mapper, IStringLocalizer<DeleteByIdCommandHandler> localizer)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _localizer = localizer;
        }
        public async Task<Response> Handle(GetAllPharmacyQuery query, CancellationToken cancellationToken)
        {
            var pharmacies = await _unitofWork.Repository<Domain.Models.Pharmacy>().GetAllAsync(i => i.OwnerId == query.Id);
            var output = _mapper.Map<List<GetAllPharmacyQueryDto>>(pharmacies);
            return await Response.SuccessAsync(output, _localizer["Success"].Value);
        }
    }
}
