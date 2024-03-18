using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Pharamcy.Application.Features.Medicines.Commands.CreateFromPurchaseInvoice
{
    public record CreateFromPurchaseInoviceCommand : IRequest<Response>
    {
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }

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
            return command.IsPartationing ? await AddMedicine<PartitionMedicine>(command) : await AddMedicine<Medicine>(command);


        }
        private async Task<Response> AddMedicine<T>(CreateFromPurchaseInoviceCommand command ) where T : BaseMedicine
        {
            var pharmacy = await _unitOfWork.Repository<Domain.Models.Pharmacy>().GetItemOnAsync(i => i.Id == command.PharmacyId);

            if(pharmacy == null ) { 
            
               return await Response.FailureAsync(_localization["PharmacyNotExist"].Value);
            }


            BaseMedicine? entity =await _unitOfWork.Repository<T>().
                GetItemOnAsync(x => x.PharmacyId==command.PharmacyId&&
                (x.NormalizedEnglishName==command.EnglishName.ToUpper() || x.NationalCode == command.NationalCode||x.ArabicName==command.ArabicName));


            if(entity != null) { 
                  return await Response.FailureAsync(_localization["MedicineExist"].Value);
            }

            var medicine = command.Adapt<T>();

            await _unitOfWork.Repository<T>().AddAsync(medicine);

            await _unitOfWork.SaveAsync();
            
            await AddTracking(medicine, command);
             
           return await Response.SuccessAsync(_localization["Success"].Value);

        }
        private async Task AddTracking(BaseMedicine medicine, CreateFromPurchaseInoviceCommand? info)
        {
            if(!medicine.IsPartationing) {
                var input = (Medicine)medicine;
                input.Tracking.Add(new()
                {
                    PurchasePrice=info.PurchasePrice,
                    SalePrice=info.SalePrice,
                    Amount = 0,
                    MedicineId = medicine.Id,
                    BarCode = ""
                });
            }
            else
            {
                var input = (PartitionMedicine)medicine;
                input.Tracking.Add(new()
                {
                     PurchasePrice=info.PurchasePrice,
                      SalePrice= info.SalePrice,
                       TabletsAvailableAmount=0,
                    PartitionMedicineId = medicine.Id,
                    TabletSalePrice = info.Partation.TabletPrice ?? 0,
                    Tablets = info.Partation.TapesCount,
                    Taps = info.Partation.TapesCount,
                    BarCode = "",
                });

            }

            await _unitOfWork.SaveAsync();

        }
    }
}
