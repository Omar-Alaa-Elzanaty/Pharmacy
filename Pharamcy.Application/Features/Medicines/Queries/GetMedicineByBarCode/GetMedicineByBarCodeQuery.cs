using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByBarCode
{
    public record GetMedicineByBarCodeQuery:IRequest<Response>
    {
        public string BarCode { get; set;}
        public int PharmacyId { get; set; }
    }
    internal class GetMedicineByBarCodeQueryHandler : IRequestHandler<GetMedicineByBarCodeQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetMedicineByBarCodeQueryHandler> _localization;

        public GetMedicineByBarCodeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetMedicineByBarCodeQuery query, CancellationToken cancellationToken)
        {
            var medicine = _unitOfWork.Repository<MedicineTracking>().Entities()
                            .FirstOrDefaultAsync(x=>x.BarCode==query.BarCode && x.Medicine.PharmacyId==query.PharmacyId)
                            .Result?.Medicine;
            var isPartition = false;

            if(medicine == null)
            {
                medicine = _unitOfWork.Repository<PartitionMedicineTracking>().Entities()
                             .FirstOrDefaultAsync(x => x.BarCode == query.BarCode && x.PartitionMedicine.PharmacyId == query.PharmacyId)
                             .Result?.PartitionMedicine;
                isPartition = true;
            }

            if(medicine is null)
            {
                return await Response.FailureAsync(_localization["MedicineNotFound"].Value);
            }

            if(isPartition)
            {

            }
            else
            {

            }
            return null;
        }
    }
}
