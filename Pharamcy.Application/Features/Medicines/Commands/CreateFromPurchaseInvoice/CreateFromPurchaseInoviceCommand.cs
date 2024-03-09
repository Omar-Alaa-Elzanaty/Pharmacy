﻿using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Medicines.Commands.CreateFromPurchaseInvoice
{
    public record CreateFromPurchaseInoviceCommand : IRequest<Response>
    {
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public double PurchasePrice { get; set; }
        public double SellingPrice { get; set; }
        public string Type { get; set; }
        public int? NationalCode { get; set; }
        public CreateFromPurchaseInoviceCommandPartitionInfo? Partation { get; set; }
        public bool IsPartationing { get; set; }
        public int PharmacyId { get; set; }
    }
    public record CreateFromPurchaseInoviceCommandPartitionInfo
    {
        public double? TabletPrice { get; set; }
        public int? TabletCount { get; set; }
        public int TapesCount { get; set; }
    }
    internal class CreateFromPurchaseInoviceHandler : IRequestHandler<CreateFromPurchaseInoviceCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<CreateFromPurchaseInoviceHandler> _localization;

        public CreateFromPurchaseInoviceHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<CreateFromPurchaseInoviceHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<Response> Handle(CreateFromPurchaseInoviceCommand command, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Medicine>()
                .GetItemOnAsync(x => x.EnglishName == command.EnglishName || x.NationalCode == command.NationalCode);

            if (entity is not null)
            {
                return await Response.FailureAsync(_localization["MedicineExist"].Value);
            }

            if (command.IsPartationing && command.Partation is not null)
            {
                var paritionMedicine = entity.Adapt<PartitionMedicine>();

                await _unitOfWork.Repository<PartitionMedicine>().AddAsync(paritionMedicine);
                await _unitOfWork.SaveAsync();

                paritionMedicine.PartitionMedicineTrackings.Add(new()
                {
                    SalePrice = command.SellingPrice,
                    PartitionMedicineId = paritionMedicine.Id,
                    TabletSalePrice = (double)command.Partation.TabletPrice!,
                    TabletsCount = command.Partation.TapesCount,
                    TapesCount = command.Partation.TapesCount,
                    Amount = 0,
                    BarCode = "",
                });

                await _unitOfWork.Repository<PartitionMedicine>().UpdateAsync(paritionMedicine);
                await _unitOfWork.SaveAsync();
            }
            else
            {
                var medicine = entity.Adapt<Medicine>();

                await _unitOfWork.Repository<Medicine>().AddAsync(medicine);
                await _unitOfWork.SaveAsync();

                medicine.Tracking.Add(new()
                {
                    SalePrice = command.SellingPrice,
                    PurchasePrice = command.PurchasePrice,
                    Amount = 0,
                    MedicineId = medicine.Id
                });

                await _unitOfWork.Repository<Medicine>().UpdateAsync(medicine);
                await _unitOfWork.SaveAsync();
            }

            return await Response.SuccessAsync(_localization["Success"].Value);
        }
    }
}
