using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Deliveries.Commands.Delete
{
    public record DeleteDeliveryCommand : IRequest<Response>
    {
        public int DeliveryId { get; set; }
        public int PharmacyId { get; set; }
    }

    internal class DeleteDeliveryCommandHandler : IRequestHandler<DeleteDeliveryCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<DeleteDeliveryCommandHandler> _localization;
        public DeleteDeliveryCommandHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<DeleteDeliveryCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<Response> Handle(DeleteDeliveryCommand query, CancellationToken cancellationToken)
        {
            var pharmacy = await _unitOfWork.Repository<Domain.Models.Pharmacy>().GetByIdAsync(query.PharmacyId);

            var delivery = pharmacy.Deliveries.FirstOrDefault(x => x.Id == query.DeliveryId);

            if (delivery == null)
            {
                return await Response.FailureAsync(_localization["InvalidRequest"].Value);
            }

            pharmacy.Deliveries.Remove(delivery);

            await _unitOfWork.Repository<Domain.Models.Pharmacy>().UpdateAsync(pharmacy);
            await _unitOfWork.SaveAsync();

            return await Response.SuccessAsync(_localization["Success"].Value);
        }
    }
}
