using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.MedicalTypes.Queries
{
    public record GetAllMedicalTypesQuery:IRequest<Response>
    {
        public string Keyword { get; set; }
    }

    internal class GetAllMedicalTypesQueryHandler : IRequestHandler<GetAllMedicalTypesQuery, Response>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMedicalTypesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Response> Handle(GetAllMedicalTypesQuery query, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.Repository<MedicalType>().Entities()
                .Where(x => (query.Keyword != null && query.Keyword.Count() == 0) ?
                x.Name.ToLower().Trim().Contains(query.Keyword.ToLower().Trim()) : true)
                .ToListAsync();


            var medicalTypes = entities.Adapt<List<GetAllMedicalTypesQueryDto>>();

            return await Response.SuccessAsync(medicalTypes);
        }
    }
}
