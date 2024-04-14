using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Pharamcy.Application.Features.Medicines.Queries.GetMedicineForSalesInvoiceByName;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCodeSaleInvoice
{
    public record GetMedicineByBarCodeSaleInvoiceQuery:IRequest<Response>
    {
        public int PharmacyId { get; set; }
        public string BarCode { get; set; }
    }

    internal class GetMedicineByBarCodeSaleInvoiceQueryHandler : IRequestHandler<GetMedicineByBarCodeSaleInvoiceQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetMedicineByBarCodeSaleInvoiceQueryHandler> _localization;

        public GetMedicineByBarCodeSaleInvoiceQueryHandler(
            IStringLocalizer<GetMedicineByBarCodeSaleInvoiceQueryHandler> localization,
            IUnitOfWork unitOfWork)
        {
            _localization = localization;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetMedicineByBarCodeSaleInvoiceQuery query, CancellationToken cancellationToken)
        {
            var medicineTracking = await _unitOfWork.Repository<MedicineTracking>().Entities()
                        .SingleOrDefaultAsync(x => x.Medicine.PharmacyId == query.PharmacyId && x.BarCode == query.BarCode);

            if(medicineTracking is not null)
            {
                return await Response.SuccessAsync(new GetMedicineByBarCodeSaleInvoiceQueryDto()
                {
                    Id = medicineTracking.MedicineId,
                    Name = medicineTracking.Medicine.EnglishName,
                    IsPartationing = false,
                    MedicineDetails = medicineTracking.Adapt<MedicineDetails>()
                });
            }

            var partitionMedicineTracking = await _unitOfWork.Repository<PartitionMedicineTracking>().Entities()
                     .SingleOrDefaultAsync(x => x.PartitionMedicine.PharmacyId == query.PharmacyId && x.BarCode == query.BarCode);

            if(partitionMedicineTracking is not null)
            {
                var ParitionMedicineInfo = new GetMedicineByBarCodeSaleInvoiceQueryDto()
                {
                    Id = partitionMedicineTracking.PartitionMedicineId,
                    Name = partitionMedicineTracking.PartitionMedicine.EnglishName,
                    IsPartationing = true,
                    PartitionMedicineDetails = partitionMedicineTracking.Adapt<PartitionMedicineDetails>()
                };
                ParitionMedicineInfo.PartitionMedicineDetails.TapsAvailableAmount =
                                    partitionMedicineTracking.Amount / partitionMedicineTracking.Taps;

                return await Response.SuccessAsync(partitionMedicineTracking);
            }

            return await Response.FailureAsync(_localization["MedicineNotFound"].Value);
        }
    }
}
