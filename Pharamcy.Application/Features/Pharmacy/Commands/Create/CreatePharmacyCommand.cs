using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Media;
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
        public string PhoneNumber { get; set; }
        public IFormFile? Logo { get; set; }
        public string OwnerId { get; set; }

    };
    internal class CreatePharmacyCommandHandler : IRequestHandler<CreatePharmacyCommand, Response>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;
        private readonly IStringLocalizer<CreatePharmacyCommandHandler> _localizer;


        public CreatePharmacyCommandHandler(
            IUnitOfWork unitofWork,
            IMapper mapper,
            IStringLocalizer<CreatePharmacyCommandHandler> localizer,
            IMediaService mediaService)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _localizer = localizer;
            _mediaService = mediaService;
        }

        public async Task<Response> Handle(CreatePharmacyCommand command, CancellationToken cancellationToken)
        {

            var oldpharmacy = await _unitofWork.Repository<Domain.Models.Pharmacy>().GetItemOnAsync(p => p.Name == command.Name);
            if (oldpharmacy != null)
                return await  Response.FailureAsync(_localizer["PharmacyExist"].Value);

            var pharmacy = _mapper.Map<Domain.Models.Pharmacy>(command);

            if(command.Logo != null)
            {
                pharmacy.PharmacyLogo = await _mediaService.SaveAsync(command.Logo);
            }

            await _unitofWork.Repository<Domain.Models.Pharmacy>().AddAsync(pharmacy);
            await _unitofWork.SaveAsync();

            return await Response.SuccessAsync(pharmacy.Id,_localizer["Success"].Value); 
        }

    }
}
