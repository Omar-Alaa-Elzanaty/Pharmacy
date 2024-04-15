using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapsterMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Clients.Commands.Update
{
    public record UpdateClientCommand:IRequest<Response>
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string Address { get; set; }
        public double Indebtedness { get; set; }
        public int LocalDiscount { get; set; }
        public int CreditLimit { get; set; }
        public bool IsCompany { get; set; }
        public bool OnlyCash { get; set; }
        public int PointsForCurrency { get; set; }
        public int TotalPoints { get; set; }
    }

    internal class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<UpdateClientCommandHandler> _localization;
        public UpdateClientCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer<UpdateClientCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _localization = localizer;
        }

        public async Task<Response> Handle(UpdateClientCommand query, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.Repository<Client>().GetByIdAsync(query.id);

            if(client is null)
            {
                return await Response.FailureAsync(_localization["ClientNotExist"].Value);
            }

            _mapper.Map(query, client);

            await _unitOfWork.Repository<Client>().UpdateAsync(client);
            await _unitOfWork.SaveAsync();

            return await Response.SuccessAsync(client.Id, _localization["Success"].Value);
        }
    }
}
