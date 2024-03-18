using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCode
{
    public record GetMedicineByBarCodeQuery : IRequest<Response>
    {
        public string BarCode { get; set; }
        public int PharmacyId { get; set; }
    }
    internal class GetMedicineByKeyQueryHandler : IRequestHandler<GetMedicineByBarCodeQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetMedicineByKeyQueryHandler> _localization;

        public GetMedicineByKeyQueryHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<GetMedicineByKeyQueryHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<Response> Handle(GetMedicineByBarCodeQuery query, CancellationToken cancellationToken)
        {
            var medicine = _unitOfWork.Repository<MedicineTracking>().Entities()
                            .FirstOrDefaultAsync(x => (x.BarCode== query.BarCode||
                            x.Medicine.ShortCode==int.Parse(query.BarCode)||
                            x.Medicine.NationalCode== int.Parse(query.BarCode)) && x.Medicine.PharmacyId == query.PharmacyId)
                            .Result?.Medicine;

            if (medicine is null)
            {
                var partitionmedicine = _unitOfWork.Repository<PartitionMedicineTracking>().Entities()
                            .FirstOrDefaultAsync(x => (x.BarCode == query.BarCode ||
                            x.PartitionMedicine.ShortCode.ToString() == query.BarCode ||
                            x.PartitionMedicine.NationalCode.ToString() == query.BarCode) && x.PartitionMedicine.PharmacyId == query.PharmacyId)
                            .Result?.PartitionMedicine;

                if (partitionmedicine is null)
                {
                    return await Response.FailureAsync(_localization["MedicineNotFound"].Value);
                }

                var partitionMedicineinfo = await GetPartitionMedicineInfo(partitionmedicine, query.BarCode);
                return await Response.SuccessAsync(partitionMedicineinfo, _localization["Success"].Value);
            }

            var medicineInfo = await GetMedicineInfo(medicine, query.BarCode);

            return await Response.SuccessAsync(medicineInfo, _localization["Success"].Value);
        }

        private async Task<GetMedicineByBarCodeQueryDto> GetMedicineInfo(Medicine medicine, string Keyword)
        {
            MedicineTracking? trackingInfo= medicine.Tracking.SingleOrDefault(i=>i.BarCode==Keyword)??medicine.Tracking.LastOrDefault();

           
                 
            return new()
            {
                Id = medicine.Id,
                Amount = trackingInfo.Amount,
                EnglishName = medicine.EnglishName,
                PurchasePrice = trackingInfo.PurchasePrice,
                BaseDiscount = medicine.BuyDiscount ?? 0,
                AdditionalTaxes = 14,
                SellingPrice = trackingInfo.SalePrice,
                IsPartationing=false
            };
        }
        private async Task<GetPartitionMedicineByBarCodeQueryDto> GetPartitionMedicineInfo(PartitionMedicine medicine, string barCode)
        {
            PartitionMedicineTracking? trackingInfo = medicine.Tracking.SingleOrDefault(x => x.BarCode == barCode )??medicine.Tracking.LastOrDefault();

            

            return new()
            {
                Id = medicine.Id,
                Amount = trackingInfo.Amount,
                EnglishName = medicine.EnglishName,
                PurchasePrice = trackingInfo.PurchasePrice,
                BaseDiscount = medicine.BuyDiscount ?? 0,
                AdditionalTaxes = 14,
                SellingPrice = trackingInfo.SalePrice,
                TabletsAmount = trackingInfo.Tablets,
                 TapesAmount=trackingInfo.Taps,
                IsPartationing = true    
            };
        }
    }
}
