using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Mapster;
using MediatR;
using MediatR.NotificationPublishers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Clients.Commands.Create
{
    public record CreateClientCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public int PharmacyId { get; set; }
    }

    internal class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<CreateClientCommandHandler> _localization;
        private readonly IPharmacyRepository _repository;
        private readonly IValidator<CreateClientCommand> _validator;
        private readonly IHttpContextAccessor _context;

        public CreateClientCommandHandler(IUnitOfWork unitOfWork,
            IStringLocalizer<CreateClientCommandHandler> localization,
            IPharmacyRepository repository,
            IValidator<CreateClientCommand> validator,
            IHttpContextAccessor context)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
            _repository = repository;
            _validator = validator;
            _context = context;
        }

        public async Task<Response> Handle(CreateClientCommand command, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);

            if (validationResult.IsValid)
            {
                return await Response.FailureAsync(validationResult.Errors.First().ErrorMessage);
            }

            var userId = _context.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                return await Response.FailureAsync(_localization["InvalidRequest"].Value);
            }

            var foundPharmacy = _repository.FindByUserId(userId).Result.Any(x => x == command.PharmacyId);

            if (!foundPharmacy)
            {
                return await Response.FailureAsync(_localization["InvalidRequest"].Value);
            }

            var client = command.Adapt<Client>();

            await _unitOfWork.Repository<Client>().AddAsync(client);
            await _unitOfWork.SaveAsync();

            return await Response.SuccessAsync(client.Id, _localization["Success"].Value);
        }
    }
}
