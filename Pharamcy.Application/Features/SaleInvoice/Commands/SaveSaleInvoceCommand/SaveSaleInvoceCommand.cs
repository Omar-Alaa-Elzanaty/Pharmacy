using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Identity;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SaleInvoice.Commands.SaveSaleInvoceCommand
{
    public class SaleInvoiceMedicine
    {

        public int MedicineId { get; set; }
        public int TrackingId { get; set; }
        public int? Amount { get; set; }
        public int? Taps { get; set; }
        public int? Tablets { get; set; }
        public double SalePrice { get; set; }
        public int Discount { get; set; }
        public int Taxis { get; set; }
        public double PriceAfterDiscount { get; set; }
        public bool IsPartition { get; set; }

        public DateOnly ExpireDate { get; set; }
    }
    public class SaveSaleInvoceCommand : IRequest<Response>
    {
        
        public string UserId { get; set; }
        public int PharmacyId { get; set; }
        public int? ClientId { get; set; }
        public double TotalOfSalePrice { get; set; }
        public double TotalDiscount { get; set; }
        public double AdditionalValue { get; set; }
        public double TotalOfSalePriceAfterDiscount { get; set; }
        public double Paied { get; set; }
        public double TermAmount { get; set; }
        public string DeliveryName { get; set; }
        public string Notes { get; set; }
        public string InvoiceWriter { get; set; }
        public List<SaleInvoiceMedicine> Items { get; set; }
    }

    public class SaveSaleInvoceCommandHandler : IRequestHandler<SaveSaleInvoceCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SaveSaleInvoceCommandHandler> _localizer;
        private readonly IMapper mapper;


        public SaveSaleInvoceCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<SaveSaleInvoceCommandHandler> localizer, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
            this.mapper = mapper;
        }

        public async Task<Response> Handle(SaveSaleInvoceCommand command, CancellationToken cancellationToken)
        {
            var pharmacy = await _unitOfWork.Repository<Domain.Models.Pharmacy>().GetItemOnAsync(i => i.Id == command.PharmacyId);

            if (pharmacy == null) 
            { 
                return await Response.FailureAsync(_localizer["PharmacyNotExist"].Value);
            }
            if (pharmacy.OwnerId != command.UserId)
            {
                return await Response.FailureAsync("UserNotFound");
            }

            if (command.ClientId != null)
            {
                var client = await _unitOfWork.Repository<Client>().GetItemOnAsync(i => i.Id == command.ClientId&&i.PharmacyId==command.PharmacyId);

                if (client == null)
                {
                    return await Response.FailureAsync(_localizer["ClientNotExist"].Value);
                }

                client.Indebtedness += command.TermAmount;
            }


            if (command.TotalOfSalePriceAfterDiscount != (100 - (command.TotalOfSalePrice / command.TotalDiscount)) * command.TotalOfSalePrice)
            {
                return await Response.FailureAsync("Wrong Calculations");
            }
            var asd = command.Adapt<SalesInvoice>();
            
            var qwe=mapper.Map<SalesInvoice>(command);

            await _unitOfWork.Repository<SalesInvoice>().AddAsync(command.Adapt<SalesInvoice>());


            foreach (var item in command?.Items)
            {
                if (item.IsPartition)
                {
                    var medicine = await _unitOfWork.Repository<PartitionMedicine>().GetItemOnAsync(i => i.Id == item.MedicineId&&i.PharmacyId==command.PharmacyId);
                    if (medicine == null)
                    {
                        return await Response.FailureAsync(_localizer["MedicineNotExist"].Value);
                    }
                    var track = medicine.Tracking.FirstOrDefault(i => i.Id == item.TrackingId);
                    if (track == null)
                    {
                        return await Response.FailureAsync(_localizer["MedicineNotExist"].Value);
                    }
                    var order = item?.Amount * track.Taps * track.Tablets + item?.Taps * track.Tablets + item?.Tablets;
                    if (track.TabletsAvailableAmount - order < 0)
                    {
                        return await Response.FailureAsync("This Amount Is bigger than current amount");
                    }
                    track.TabletsAvailableAmount -= order ?? 0;
                }
                else
                {
                    var medicine = await _unitOfWork.Repository<Medicine>().GetItemOnAsync(i => i.Id == item.MedicineId && i.PharmacyId == command.PharmacyId);
                    if (medicine == null)
                    {
                        return await Response.FailureAsync(_localizer["MedicineNotExist"].Value);
                    }
                    var track = medicine.Tracking.FirstOrDefault(i => i.Id == item.TrackingId);
                    if (track == null)
                    {
                        return await Response.FailureAsync(_localizer["MedicineNotExist"].Value);
                    }

                    if (track.Amount - item.Amount < 0)
                    {
                        return await Response.FailureAsync("This Amount Is bigger than current amount");
                    }
                    track.Amount -= item.Amount ?? 0;
                }
            }
            await _unitOfWork.SaveAsync();

            return await Response.SuccessAsync(_localizer["Success"].Value);

        }
    }
}
