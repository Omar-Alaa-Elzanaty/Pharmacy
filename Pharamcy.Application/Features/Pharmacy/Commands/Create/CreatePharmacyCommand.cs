﻿using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Shared;
namespace Pharamcy.Application.Features.Pharmacy.Commands.Create
{
    public record CreatePharmacyCommand : IRequest<Response>
    {
        public string Address { get; set; }
        public string Name { get; set; }
        public string ArabicHeader { get; set; }
        public string EnglishHeader { get; set; }
        public string ArabicFooter { get; set; }
        public string EnglishFooter { get; set; }
        public string AdminId { get; set; }

    };
    internal class CreatePharmacyCommandHandler : IRequestHandler<CreatePharmacyCommand, Response>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<CreatePharmacyCommandHandler> _localizer;


        public CreatePharmacyCommandHandler(IUnitOfWork unitofWork, IMapper mapper, IStringLocalizer<CreatePharmacyCommandHandler> localizer)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<Response> Handle(CreatePharmacyCommand command, CancellationToken cancellationToken)
        {

            var oldpharmacy = await _unitofWork.Repository<Domain.Models.Pharmacy>().GetItemOnAsync(p => p.Name == command.Name);
            if (oldpharmacy != null)
                return await  Response.FailureAsync(_localizer["PharmacyExist"].Value);

            var pharmacy = _mapper.Map<Domain.Models.Pharmacy>(command);

            await _unitofWork.Repository<Domain.Models.Pharmacy>().AddAsync(pharmacy);


            return await Response.SuccessAsync(_localizer["Success"].Value); 
        }

    }
}