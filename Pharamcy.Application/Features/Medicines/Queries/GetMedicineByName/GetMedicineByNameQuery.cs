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

            List<GetMedicineByNameQueryDto> response=new();
            foreach (var item in entities)
            {
                if(item.IsPartationing) {

                    response.Add(_mapper.Map<GetMedicineByNameQueryDto>((PartitionMedicine)item));
                    


                }

                else
                    response.Add(_mapper.Map<GetMedicineByNameQueryDto>(item));


            }

            

            return await Response.SuccessAsync(response, _localization["Success"].Value);
        }
    }
}
