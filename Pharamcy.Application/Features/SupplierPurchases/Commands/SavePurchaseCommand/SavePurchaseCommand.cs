using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Media;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;

namespace Pharamcy.Application.Features.SupplierPurchases.Commands.SavePurchaseCommand
{
    public class Product
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int RealAmount => Amount + Bonse;
        public int Bonse { get; set; }

        public double UnitPrice { get; set; }
        public int Taxis { get; set; }
        public int BaseDiscount { get; set; }
        public int AdditionalDiscount { get; set; }
        public double PurchasePriceForUnit => PurchasePrice / Amount;
        public double PurchasePrice { get; set; }
        public double SalePrice { get; set; }
        public double SalePriceForUnit => SalePrice / Amount;
        public DateOnly ExpireDate { get; set; }
    }
    public class PartitionProduct
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int RealAmount => Amount + Bonse;
        public int Bonse { get; set; }

        public decimal UnitPrice { get; set; }
        public int Taps { get; set; }
        public int Tablets { get; set; }
        public int Taxis { get; set; }
        public int BaseDiscount { get; set; }
        public int AdditionalDiscount { get; set; }
        public double PurchasePrice { get; set; }
        public double PurchasePriceForUnit => PurchasePrice / Amount;
        public double SalePriceForUnit => SalePrice / Amount;
        public double SalePrice { get; set; }
        public int TabletsAvailableAmount => RealAmount * Taps * Tablets;
        public double TabletSalePrice { get; set; }
        public DateOnly ExpireDate { get; set; }
    }
    public class SavePurchaseCommand : IRequest<Response>
    {
        public List<Product>? Products { get; set; }=[];
        public List<PartitionProduct>? PartitionProducts { get; set; } = [];
        public bool IsClosed { get; set; }
        public double TermAmount { get; set; }
        public int DiscountCostPrecent { get; set; }
        public string CreatorName { get; set; }
        public string SupplierName { get; set; }
        public int SupplierId { get; set; }


        public double TotalCost { get; set; }
        public double Paied { get; set; }
        public string ImportInvoiceNumber { get; set; }
        public string Notes { get; set; }
        public IFormFile InvoiceImage { get; set; }
        public int PharmacyId { get; set; }
    }


    internal class SavePurchaseCommandHandler : IRequestHandler<SavePurchaseCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SavePurchaseCommandHandler> _localizer;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;

        public SavePurchaseCommandHandler(IUnitOfWork unitOfWork, IStringLocalizer<SavePurchaseCommandHandler> localizer, IMapper mapper, IMediaService mediaService)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
            _mapper = mapper;
            _mediaService = mediaService;
        }

        public async Task<Response> Handle(SavePurchaseCommand command, CancellationToken cancellationToken)
        {

            var pharmacy = await _unitOfWork.Repository<Domain.Models.Pharmacy>().GetItemOnAsync(i => i.Id == command.PharmacyId);

            if (pharmacy == null)
                return await Response.FailureAsync(_localizer["PharmacyNotExist"]);



            var purchaseinvoice = _mapper.Map<PurchaseInvoice>(command);

            purchaseinvoice.InvoiceImageUrl = await _mediaService.SaveAsync(command.InvoiceImage);

            await _unitOfWork.Repository<PurchaseInvoice>().AddAsync(purchaseinvoice);






                purchaseinvoice.Items.AddRange(command?.Products.Adapt<List<PurchaseInvoiceItem>>()??new List<PurchaseInvoiceItem>());


                purchaseinvoice.Items.AddRange(command?.PartitionProducts.Adapt<List<PurchaseInvoiceItem>>() ?? new List<PurchaseInvoiceItem>());



            var supplier = await _unitOfWork.Repository<Supplier>().GetItemOnAsync(i => i.Id == command.SupplierId);

            if (supplier == null)
            {

                return await Response.FailureAsync("SupplierNotExist");
            }

            supplier.FinancialDue = command.TermAmount;

                foreach (var item in command?.Products)
                {
                    var medicine = await _unitOfWork.Repository<Medicine>().GetItemOnAsync(i => i.Id == item.MedicineId);
                    if (medicine == null)
                    {
                        return await Response.FailureAsync(_localizer["Faild"]);
                    }

                    if (medicine.Tracking.AsReadOnly().Any(x => x.PurchasePrice == item.PurchasePriceForUnit))
                    {
                        medicine.Tracking.FirstOrDefault(i => i.PurchasePrice == item.PurchasePriceForUnit)!.Amount += item.RealAmount;
                    }
                    else
                    {
                       medicine.Tracking.Add(_mapper.Map<MedicineTracking>(item));
                    }
                }
            //if (command.Products is not null)
            //{
            //}
            
                foreach (var item in command?.PartitionProducts)
                {
                    var medicine = await _unitOfWork.Repository<PartitionMedicine>().GetItemOnAsync(i => i.Id == item.MedicineId);
                    if (medicine == null)
                    {
                        return await Response.FailureAsync(_localizer["MedicineNotFound"].Value);
                    }

                    if (medicine.Tracking.Any(i => i.PurchasePrice == item.PurchasePriceForUnit && i.Taps == item.Taps && i.Tablets == item.Tablets))
                    {
                        medicine.Tracking.
                            FirstOrDefault(i => i.PurchasePrice == item.PurchasePriceForUnit && i.Taps == item.Taps && i.Tablets == item.Tablets)!.TabletsAvailableAmount += item.TabletsAvailableAmount;
                    }
                    else
                    {
                        medicine.Tracking.Add(_mapper.Map<PartitionMedicineTracking>(item));
                    }
                }
            //if(command.PartitionProducts is not null)
            //{
            //}
           
            await _unitOfWork.SaveAsync();
            return await Response.SuccessAsync(_localizer["Success"]);

        }
    }


}
