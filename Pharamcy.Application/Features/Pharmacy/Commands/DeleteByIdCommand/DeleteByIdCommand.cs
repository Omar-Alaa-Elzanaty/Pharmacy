using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Pharmacy.Commands.DeleteByIdCommand
{
    public record DeleteByIdCommand:IRequest<Response> {
        public int Id { get; set; }
    };

    internal class DeleteByIdCommandHandler : IRequestHandler<DeleteByIdCommand, Response>
    {
        private readonly IUnitOfWork _unitofWork;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<DeleteByIdCommandHandler> _localizer;

        public DeleteByIdCommandHandler(IUnitOfWork unitofWork, IMapper mapper, IStringLocalizer<DeleteByIdCommandHandler> localizer)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
            _localizer = localizer;
        }
        public async Task<Response> Handle(DeleteByIdCommand command, CancellationToken cancellationToken)
        {
            var response=new Response();
            if (_unitofWork.Repository<Domain.Models.Pharmacy>().GetAsync(p => p.Id == command.Id) == null)
                return  await Response.FailureAsync(_localizer["PharmacyNotExist"]);
            var pharmacy =_mapper.Map<Domain.Models.Pharmacy>(command);
             await _unitofWork.Repository<Domain.Models.Pharmacy>().DeleteAsync(pharmacy.Id);
            return await Response.SuccessAsync(_localizer["sucess"]);
        }
    }
}
