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

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByName
{
    public record GetMedicineByNameQuery:IRequest<Response>
    {
        public string Name { get; set; }
        public int PharmacyId { get; set; }
    }
    public class GetMedicineByNamequeryHandler : IRequestHandler<GetMedicineByNameQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetMedicineByNamequeryHandler> _localization;

        public GetMedicineByNamequeryHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<GetMedicineByNamequeryHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<Response> Handle(GetMedicineByNameQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<Medicine>().Entities()
                        .SingleOrDefaultAsync(x => x.EnglishName == query.Name || x.ArabicName == query.Name);

            if (entity == null)
            {
                return await Response.FailureAsync(_localization["MedicineNotFound"].Value);
            }

            var medicine = entity.Adapt<GetMedicineByNameQuery>();

            return await Response.SuccessAsync(medicine, _localization["Success"].Value);
        }
    }
}
