using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        private readonly IMapper _mapper;

        public GetMedicineByNamequeryHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<GetMedicineByNamequeryHandler> localization,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _mapper = mapper;
        }

        public async Task<Response> Handle(GetMedicineByNameQuery query, CancellationToken cancellationToken)
        {
            if (query.Name == null) return await Response.FailureAsync(_localization["NameRequired"]);

           
            var entities =   _unitOfWork.Repository<Medicine>().
            GetAllAsync(x => x.PharmacyId == query.PharmacyId &&
            (x.NormalizedEnglishName.Contains(query.Name.ToUpper()) || x.ArabicName.Contains(query.Name))).Result.ToList();



            var Partitionentities =  _unitOfWork.Repository<PartitionMedicine>().
            GetAllAsync(x => x.PharmacyId == query.PharmacyId &&
            (x.NormalizedEnglishName.Contains(query.Name.ToUpper()) || x.ArabicName.Contains(query.Name))).Result.ToList();




            List<GetMedicineByNameQueryDto> response = [.. entities?.Adapt<List<GetMedicineByNameQueryDto>>(),.. Partitionentities?.Adapt<List<GetMedicineByNameQueryDto>>()];
            


            return await Response.SuccessAsync(response, _localization["Success"].Value);
        }
    }
}
