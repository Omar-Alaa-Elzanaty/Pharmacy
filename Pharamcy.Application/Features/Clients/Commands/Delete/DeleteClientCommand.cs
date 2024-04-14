using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Clients.Commands.Delete
{
    public record DeleteClientCommand:IRequest<Response>
    {
        public int ClientId { get; set; }
        public int PharamacyId { get; set; }
    }

    internal class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<DeleteClientCommandHandler> _localization;
        private readonly IHttpContextAccessor _context;
        private readonly IPharmacyRepository _repository;

        public DeleteClientCommandHandler(IUnitOfWork unitOfWork,
            IHttpContextAccessor context,
            IStringLocalizer<DeleteClientCommandHandler> localization,
            IPharmacyRepository repository)
        {
            _unitOfWork = unitOfWork;
            _context = context;
            _localization = localization;
            _repository = repository;
        }

        public async Task<Response> Handle(DeleteClientCommand command, CancellationToken cancellationToken)
        {
            var userId = _context.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(userId is null)
            {
                return await Response.FailureAsync(_localization["InvalidRequest"].Value);
            }

            var foundPharmacy = _repository.FindByUserId(userId).Result.Any(x => x == command.PharamacyId);
            
            if(!foundPharmacy)
            {
                return await Response.FailureAsync(_localization["UnAuthorized"].Value);
            }

            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(command.ClientId);

            if(client == null)
            {
                return await Response.FailureAsync(_localization["ClientNotExist"].Value);
            }

            await _unitOfWork.Repository<Client>().DeleteAsync(client);
            await _unitOfWork.SaveAsync();

            return await Response.SuccessAsync(_localization["Success"].Value);
        }
    }
}
