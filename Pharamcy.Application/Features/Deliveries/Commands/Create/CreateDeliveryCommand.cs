using Mapster;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Identity;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Deliveries.Commands.Create
{
    public class CreateDeliveryCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public int PharmacyId { get; set; }
    }

    internal class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPharmacyRepository _pharmacyRepository;
        private readonly IStringLocalizer<CreateDeliveryCommandHandler> _localization;

        public CreateDeliveryCommandHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<CreateDeliveryCommandHandler> localization,
            IPharmacyRepository pharmacyRepository)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _pharmacyRepository = pharmacyRepository;
        }

        public async Task<Response> Handle(CreateDeliveryCommand query, CancellationToken cancellationToken)
        {
            var pharmacy = await _pharmacyRepository.CheckPharmacy(query.PharmacyId);

            if(pharmacy == null)
            {
                return await Response.FailureAsync(_localization["UnAuthorized"].Value);
            }

            var delivery = query.Adapt<Delivery>();

            await _unitOfWork.Repository<Delivery>().AddAsync(delivery);
            await _unitOfWork.SaveAsync();

            return await Response.SuccessAsync(delivery.Id);
        }
    }
}
