using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineForSalesInvoiceByName
{
    public record GetMedicineForSalesInvoiceByNameQuery:IRequest<Response>
    {
        public int PharmacyId { get; set;}
        public string Name { get; set; }
    }

    internal class GetMedicineForSalesInvoiceByNameQueryHandler : IRequestHandler<GetMedicineForSalesInvoiceByNameQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetMedicineForSalesInvoiceByNameQueryHandler> _localization;

        public GetMedicineForSalesInvoiceByNameQueryHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<GetMedicineForSalesInvoiceByNameQueryHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<Response> Handle(GetMedicineForSalesInvoiceByNameQuery query, CancellationToken cancellationToken)
        {
            var medicine = await _unitOfWork.Repository<BaseMedicine>().Entities()
                .SingleOrDefaultAsync(x => 
                query.PharmacyId == x.PharmacyId &&
                (x.EnglishName.ToLower().StartsWith(query.Name.ToLower()) || x.ArabicName.StartsWith(query.Name))
                );

            if(medicine is null)
            {
                return await Response.FailureAsync(_localization["MedicineNotFound"].Value);
            }

            var medicineInfo = new GetMedicineForSalesInvoiceByNameQueryDto()
            {
                Id = medicine.Id,
                Name = medicine.EnglishName,
                IsPartationing = medicine.IsPartationing
            };

            if (medicine.IsPartationing)
            {
                medicineInfo.PartitionMedicineDetails = await _unitOfWork.Repository<PartitionMedicineTracking>().Entities()
                                            .Where(x => x.PartitionMedicineId == medicine.Id)
                                            .Select(x => new PartitionMedicineDetails()
                                            {
                                                Id = x.Id,
                                                Amount = x.Amount,
                                                ExpireDate = x.ExpireDate,
                                                PurchasePrice = x.PurchasePrice,
                                                SalePrice = x.SalePrice,
                                                TabletSalePrice = x.TabletSalePrice,
                                                TabletsAvailableAmount= x.TabletsAvailableAmount,
                                                TapsAvailableAmount = x.Amount/x.Taps
                                            })
                                            .ToListAsync();
            }
            else
            {
                medicineInfo.MedicineDetails = await _unitOfWork.Repository<MedicineTracking>().Entities()
                                            .Where(x => x.MedicineId == medicine.Id)
                                            .ProjectToType<MedicineDetails>()
                                            .ToListAsync();
            }

            return await Response.SuccessAsync(medicineInfo);
        }
    }
}
