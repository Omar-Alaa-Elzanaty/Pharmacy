using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByKeyCode
{
    public record GetMedicineByKeyQuery : IRequest<Response>
    {
        public string Keyword { get; set; }
        public int PharmacyId { get; set; }
    }
    internal class GetMedicineByKeyQueryHandler : IRequestHandler<GetMedicineByKeyQuery, Response>
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

        public async Task<Response> Handle(GetMedicineByKeyQuery query, CancellationToken cancellationToken)
        {
            var medicine = _unitOfWork.Repository<MedicineTracking>().Entities()
                            .FirstOrDefaultAsync(x => (x.BarCode == query.Keyword || x.Medicine.EnglishName == query.Keyword||x.Medicine.ArabicName==query.Keyword) && x.Medicine.PharmacyId == query.PharmacyId)
                            .Result?.Medicine;

            if (medicine is null)
            {
                var partitionmedicine = _unitOfWork.Repository<PartitionMedicineTracking>().Entities()
                            .FirstOrDefaultAsync(x => (x.BarCode == query.Keyword || x.PartitionMedicine.EnglishName == query.Keyword || x.PartitionMedicine.ArabicName == query.Keyword) && x.PartitionMedicine.PharmacyId == query.PharmacyId)
                            .Result?.PartitionMedicine;

                if (partitionmedicine is null)
                {
                    return await Response.FailureAsync(_localization["MedicineNotFound"].Value);
                }

                var partitionMedicineinfo = await GetPartitionMedicineInfo(partitionmedicine, query.Keyword);
                return await Response.SuccessAsync(partitionMedicineinfo, _localization["Success"].Value);
            }

            var medicineInfo = await GetMedicineInfo(medicine, query.Keyword);

            return await Response.SuccessAsync(medicineInfo, _localization["Success"].Value);
        }

        private async Task<GetMedicineByKeyQueryDto> GetMedicineInfo(Medicine medicine, string barCode)
        {
            MedicineTracking trackingInfo = medicine.Tracking.SingleOrDefault(x => x.BarCode == barCode)!;

            return new()
            {
                Id = medicine.Id,
                Amount = trackingInfo.Amount,
                EnglishName = medicine.EnglishName,
                PurchasePrice = trackingInfo.PurchasePrice,
                BaseDiscount = medicine.BuyDiscount ?? 0,
                AdditionalTaxes = 14,
                SellingPrice = trackingInfo.SalePrice
            };
        }
        private async Task<GetPartitionMedicineByKeyCodeQueryDto> GetPartitionMedicineInfo(PartitionMedicine medicine, string barCode)
        {
            PartitionMedicineTracking trackingInfo = medicine.PartitionMedicineTrackings.SingleOrDefault(x => x.BarCode == barCode)!;

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
            };
        }
    }
}
