using MapsterMapper;
using MediatR;
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
           
            var entities =  _unitOfWork.Repository<Medicine>().GetAllAsync( x => x.EnglishName.Contains( query.Name) || x.ArabicName.Contains(query.Name)).Result.ToList();
           

            var partitionEntities=  _unitOfWork.Repository<PartitionMedicine>().GetAllAsync(x => x.EnglishName.Contains(query.Name) || x.ArabicName.Contains(query.Name)).Result.ToList();
               
            if(entities==null&&partitionEntities==null) 
            return await Response.FailureAsync(_localization["MedicineNotFound"].Value);

                var partitionMedicines =  _mapper.Map <List<GetMedicineByNameQueryDto>>(partitionEntities);

                  partitionMedicines.ForEach(i => i.IsPartition = true);





            var  medicines = _mapper.Map<List<GetMedicineByNameQueryDto>>(entities);
            medicines.ForEach(i=>i.IsPartition = false);    

            List<GetMedicineByNameQueryDto> response = [.. medicines,.. partitionMedicines];
            

            return await Response.SuccessAsync(response, _localization["Success"].Value);
        }
    }
}
