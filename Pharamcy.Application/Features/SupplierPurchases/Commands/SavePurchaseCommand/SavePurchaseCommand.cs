using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Pharamcy.Application.Interfaces.Media;
using Pharamcy.Application.Interfaces.Repositories;
using Pharamcy.Domain.Models;
using Pharamcy.Shared;
using System.Collections.Generic;

namespace Pharamcy.Application.Features.SupplierPurchases.Commands.SavePurchaseCommand
{
    public class Product
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int RealAmount => Amount + Bonse;
        public int Bonse { get; set; }
        public int Shelf { get; set; } = 0;

        public decimal UnitPrice { get; set; }
        public int Taxis { get; set; }
        public int BaseDiscount { get; set; }
        public int AdditionalDiscount { get; set; }
        public decimal PurchasePriceForUnit => PurchasePrice / Amount;
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal SalePriceForUnit => SalePrice / Amount;
        public DateOnly ExpireDate { get; set; }
    }
    public class PartitionProduct
    {
        public int MedicineId { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int RealAmount => Amount + Bonse;
        public int Bonse { get; set; }
        public int Shelf { get; set; } = 0;

        public decimal UnitPrice { get; set; }
        public int Taps { get; set; }
        public int Tablets { get; set; }
        public int Taxis { get; set; }
        public int BaseDiscount { get; set; }
        public int AdditionalDiscount { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal PurchasePriceForUnit => PurchasePrice / Amount;
        public decimal SalePriceForUnit => SalePrice / Amount;
        public decimal SalePrice { get; set; }
        public int TabletsAvailableAmount => RealAmount * Taps * Tablets;
        public decimal TabletSalePrice { get; set; }
        public DateOnly ExpireDate { get; set; }
    }
    public class SavePurchaseCommand : IRequest<Response>
    {
        public List<Product> Products { get; set; }
        public List<PartitionProduct> PartitionProducts { get; set; }
        public bool IsClosed { get; set; }
        public decimal TermAmount { get; set; }
        public int DiscountCostPrecent { get; set; }
        public string CreatorName { get; set; }
        public string CompanyName { get; set; }
        public decimal TotalCost { get; set; }
        public string ImportInvoiceNumber { get; set; }
        public string Notes { get; set; }
        public IFormFile InvoiceImage { get; set; }
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

            var purchaseinvoice = _mapper.Map<PurchaseInvoice>(command);
            
            await _unitOfWork.Repository<PurchaseInvoice>().AddAsync(purchaseinvoice);


            purchaseinvoice.Items.AddRange(command.Products.Adapt<IEnumerable<PruchaseInvoiceItem>>());
            
            purchaseinvoice.Items.AddRange(command.PartitionProducts.Adapt<IEnumerable<PruchaseInvoiceItem>>());
            purchaseinvoice.InvoiceImage=await _mediaService.SaveAsync(command.InvoiceImage);
            
            foreach (var item in command.Products)
            {
                var medicine = await _unitOfWork.Repository<Medicine>().GetItemOnAsync(i => i.Id == item.MedicineId);
                if (medicine == null)
                {
                    return await Response.FailureAsync(_localizer["Faild"]);
                }

                if (medicine.Tracking.Any(x => x.PurchasePrice == item.PurchasePriceForUnit))
                {

                    medicine.Tracking.FirstOrDefault(i => i.PurchasePrice == item.PurchasePriceForUnit)!.Amount += item.RealAmount;

                }

                else
                {

                    medicine.Tracking.Add(_mapper.Map<MedicineTracking>(item));

                }
            }
            foreach (var item in command.PartitionProducts)
            {
                var medicine = await _unitOfWork.Repository<PartitionMedicine>().GetItemOnAsync(i => i.Id == item.MedicineId);
                if (medicine == null)
                {
                    return await Response.FailureAsync(_localizer["Faild"]);
                }
                if ( medicine.PartitionMedicineTrackings.Any(i => i.PurchasePrice == item.PurchasePriceForUnit && i.Taps == item.Taps && i.Tablets == item.Tablets))
                {
                    medicine.PartitionMedicineTrackings.
                        FirstOrDefault(i => i.PurchasePrice == item.PurchasePriceForUnit)!.TabletsAvailableAmount += item.TabletsAvailableAmount;
                }
                else
                {
                    medicine.PartitionMedicineTrackings.Add(_mapper.Map<PartitionMedicineTracking>(item));
                }

            }

           await  _unitOfWork.SaveAsync();
            return await Response.SuccessAsync(_localizer["Success"]);

        }
    }


}
