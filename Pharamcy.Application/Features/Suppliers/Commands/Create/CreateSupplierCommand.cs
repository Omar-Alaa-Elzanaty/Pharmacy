using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.Suppliers.Commands.Create
{
    public record CreateSupplierCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public int PharmacyId { get; set; }
    }
    internal class CreateSupplierCommandHandler : IRequestHandler<CreateSupplierCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<CreateSupplierCommandHandler> _localization;
        public CreateSupplierCommandHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<CreateSupplierCommandHandler> localization)
        {
            _unitOfWork = unitOfWork;
            _localization = localization;
        }

        public async Task<Response> Handle(CreateSupplierCommand command, CancellationToken cancellationToken)
        
        {
            var entity = await _unitOfWork.Repository<Supplier>().Entities()
                        .Where(x => x.Name == command.Name && x.PharmacyId == command.PharmacyId).SingleOrDefaultAsync();

            if (entity is not null)
            {
                return await Response.FailureAsync(_localization["SupplierExist"].Value);
            }

            var supplier = command.Adapt<Supplier>();

            await _unitOfWork.Repository<Supplier>().AddAsync(supplier);
            await _unitOfWork.SaveAsync();

            return await Response.SuccessAsync(supplier.Id);
        }
    }
}
