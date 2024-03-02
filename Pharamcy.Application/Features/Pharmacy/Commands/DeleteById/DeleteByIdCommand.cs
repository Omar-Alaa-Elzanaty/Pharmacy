using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Media;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Pharmacy.Commands.DeleteById
{
    public record DeleteByIdCommand : IRequest<Response>
    {
        public int Id { get; set; }

        public DeleteByIdCommand(int id)
        {
            Id = id;
        }
    };

    internal class DeleteByIdCommandHandler : IRequestHandler<DeleteByIdCommand, Response>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;
        private readonly IStringLocalizer<DeleteByIdCommandHandler> _localizer;

        public DeleteByIdCommandHandler(
            IUnitOfWork unitofWork,
            IMapper mapper,
            IStringLocalizer<DeleteByIdCommandHandler> localizer,
            IMediaService mediaService)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _localizer = localizer;
            _mediaService = mediaService;
        }
        public async Task<Response> Handle(DeleteByIdCommand command, CancellationToken cancellationToken)
        {
            var response = new Response();
            var pharmacy = await _unitofWork.Repository<Domain.Models.Pharmacy>().GetItemOnAsync(p => p.Id == command.Id);
            if (pharmacy == null)
                return await Response.FailureAsync(_localizer["PharmacyNotExist"].Value);

            if (pharmacy.PharmacyLogo is not null)
            {
                await _mediaService.DeleteAsync(pharmacy.PharmacyLogo);
            }
            await _unitofWork.Repository<Domain.Models.Pharmacy>().DeleteAsync(pharmacy);

            return await Response.SuccessAsync(_localizer["Success"].Value);
        }
    }
}
