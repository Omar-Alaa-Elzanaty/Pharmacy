using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Deliveries.Commands.Update
{
    public record UpdateDeliveryCommand:IRequest<Response>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PharmacyId { get; set; }
    }

    internal class UpdateDeliveryCommandHandler : IRequestHandler<UpdateDeliveryCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<UpdateDeliveryCommandHandler> _localization;

        public UpdateDeliveryCommandHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<UpdateDeliveryCommandHandler> localziation)
        {
            _unitOfWork = unitOfWork;
            _localization = localziation;
        }

        public async Task<Response> Handle(UpdateDeliveryCommand command, CancellationToken cancellationToken)
        {
            var pharmacy = await _unitOfWork.Repository<Domain.Models.Pharmacy>().GetByIdAsync(command.Id);

            if(pharmacy is null)
            {
                return await Response.FailureAsync(_localization["InvalidRequest"].Value);
            }

            var delivery = pharmacy.Deliveries.SingleOrDefault(x => x.Id == command.Id);

            if(delivery is null)
            {
                return await Response.FailureAsync(_localization["InvalidRequest"].Value);
            }

            delivery.Name = command.Name;

            await _unitOfWork.Repository<Domain.Models.Pharmacy>().UpdateAsync(pharmacy);
            await _unitOfWork.SaveAsync();

            return await Response.SuccessAsync(_localization["Success"].Value);
        }
    }
}
