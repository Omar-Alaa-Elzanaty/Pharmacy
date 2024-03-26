using Mapster;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Medicines.Queries.GetMedicineByNamePagination
{
    public record GetMedicineByNamePaginationQuery:PaginationRequest,IRequest<Response>
    {
        public string Name { get; set; }
        public int PharmacyId { get; set; }
        public bool? IsPartationing { get; set; }
    }

    public class GetMedicineByNamePaginationQueryHandler : IRequestHandler<GetMedicineByNamePaginationQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<GetMedicineByNamePaginationQueryHandler> _localizer;

        public GetMedicineByNamePaginationQueryHandler(IUnitOfWork unitOfWork, IStringLocalizer<GetMedicineByNamePaginationQueryHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
        }

        public async Task<Response> Handle(GetMedicineByNamePaginationQuery query, CancellationToken cancellationToken)
        {
            if (query.Name is null)
                return await Response.FailureAsync(_localizer["NameRequired"].Value);

            List<GetMedicineByNamePaginationQueryDto> medicines;

          if(query.IsPartationing is null)
            {
                var entities= _unitOfWork.Repository<Medicine>().Entities().Where(i=>i.NormalizedEnglishName.Contains(query.Name.ToUpper()));    
                var Partitionentities= _unitOfWork.Repository<PartitionMedicine>().Entities().Where(i=>i.NormalizedEnglishName.Contains(query.Name.ToUpper()));

                medicines = [..entities?.Adapt<List<GetMedicineByNamePaginationQueryDto>>(),.. Partitionentities?.Adapt<List<GetMedicineByNamePaginationQueryDto>>()];

                 medicines.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize);

            }
          else if(query.IsPartationing==true)
            {
                var Partitionentities = _unitOfWork.Repository<PartitionMedicine>().Entities().Where(i => i.NormalizedEnglishName.Contains(query.Name.ToUpper()));

                medicines = [ .. Partitionentities.Adapt<List<GetMedicineByNamePaginationQueryDto>>()];

            }
            else
            {

                var entities = _unitOfWork.Repository<Medicine>().Entities().Where(i => i.NormalizedEnglishName.Contains(query.Name.ToUpper()));

                medicines = [.. entities?.Adapt<List<GetMedicineByNamePaginationQueryDto>>()];

            }

          return await Response.SuccessAsync(medicines, _localizer["Succeess"].Value);    
        }
    }

}
