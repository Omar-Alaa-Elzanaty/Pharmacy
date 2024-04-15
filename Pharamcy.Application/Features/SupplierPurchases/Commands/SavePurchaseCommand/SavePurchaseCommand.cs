using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
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
        public string ExpireDate { get; set; }
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
        public string ExpireDate { get; set; }
    }
    public class SavePurchaseCommand : IRequest<Response>
    {
        public List<Product>? Products { get; set; } = [];
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
        public IFormFile? InvoiceImage { get; set; }
        public int PharmacyId { get; set; }
        public string userId { get; set; }
    }


    internal class SavePurchaseCommandHandler : IRequestHandler<SavePurchaseCommand, Response>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SavePurchaseCommandHandler> _localizer;
        private readonly IMapper _mapper;
        private readonly IMediaService _mediaService;
        private readonly IPharmacyRepository _pharmacyRepository;

        public SavePurchaseCommandHandler(
            IUnitOfWork unitOfWork,
            IStringLocalizer<SavePurchaseCommandHandler> localizer,
            IMapper mapper,
            IMediaService mediaService,
            IPharmacyRepository pharmacyRepository)
        {
            _unitOfWork = unitOfWork;
            _localizer = localizer;
            _mapper = mapper;
            _mediaService = mediaService;
            _pharmacyRepository = pharmacyRepository;
        }

        public async Task<Response> Handle(SavePurchaseCommand command, CancellationToken cancellationToken)
        {
            var ishasPharmacy = _pharmacyRepository.FindByUserId(command.userId).Result.Any(x => x == command.PharmacyId);

            if (ishasPharmacy == false)
            {
                return await Response.FailureAsync(_localizer["PharmacyNotExist"].Value);
            }
         
            if(await _unitOfWork.Repository<PurchaseInvoice>().Entities().AnyAsync(i => i.ImportInvoiceNumber == command.ImportInvoiceNumber))
            {
                return await Response.FailureAsync(_localizer["ImportInvoiceNumberExist"].Value);

            }
         
            var pharmacy = await _unitOfWork.Repository<Domain.Models.Pharmacy>().GetItemOnAsync(i => i.Id == command.PharmacyId);

            if (command.Products is not null)
            {
                var foundMedicinesCount = _unitOfWork.Repository<Medicine>()
                    .GetAllAsync(x => x.PharmacyId == command.PharmacyId && command.Products.Any(p => p.Name == x.EnglishName)).Result.Count();
                                    

                if (foundMedicinesCount != command.Products.Count)
                {
                    return await Response.FailureAsync(_localizer["MedicineNotFound"].Value);
                }
            }

            if (command.PartitionProducts is not null)
            {
                var foundMedicinesCount = _unitOfWork.Repository<PartitionMedicine>()
                    .GetAllAsync(x => x.PharmacyId == command.PharmacyId && command.PartitionProducts.Any(p => p.Name == x.EnglishName)).Result.Count();

                if (foundMedicinesCount != command.PartitionProducts.Count)
                {
                    return await Response.FailureAsync(_localizer["MedicineNotFound"].Value);
                }
            }

            var purchaseinvoice = _mapper.Map<PurchaseInvoice>(command);

            if (command.InvoiceImage != null)
            {
                purchaseinvoice.InvoiceImageUrl = await _mediaService.SaveAsync(command.InvoiceImage);
            }

            await _unitOfWork.Repository<PurchaseInvoice>().AddAsync(purchaseinvoice);
            purchaseinvoice.Items.AddRange(command?.Products.Adapt<List<PurchaseInvoiceItem>>() ?? new List<PurchaseInvoiceItem>());
            purchaseinvoice.Items.AddRange(command?.PartitionProducts.Adapt<List<PurchaseInvoiceItem>>() ?? new List<PurchaseInvoiceItem>());

            if (!command.IsClosed)
            {
                await _unitOfWork.SaveAsync();
                return await Response.SuccessAsync(_localizer["Success"]);
            }

            var supplier = await _unitOfWork.Repository<Supplier>().GetItemOnAsync(i => i.Id == command.SupplierId);

            if (supplier == null)
            {

                return await Response.FailureAsync("SupplierNotExist");
            }

            supplier.FinancialDue += command.TermAmount;

            if (!command.Products.IsNullOrEmpty())
            {
                foreach (var item in command.Products)
                {
                    var medicine = await _unitOfWork.Repository<Medicine>().GetItemOnAsync(i => i.Id == item.MedicineId);
                    if (medicine == null)
                    {
                        return await Response.FailureAsync(_localizer["Failed"]);
                    }

                    if(!DateTime.TryParse(item.ExpireDate,out DateTime result))
                    {
                        return await Response.FailureAsync("ExpireDate Is Invalid Format");
                    }


                    if (medicine.Tracking.AsReadOnly().Any(x => x.PurchasePrice == item.PurchasePriceForUnit&&x.ExpireDate==result))
                    {
                        medicine.Tracking.FirstOrDefault(i => i.PurchasePrice == item.PurchasePriceForUnit)!.Amount += item.RealAmount;
                    }
                    else
                    {
                        medicine.Tracking.Add(_mapper.Map<MedicineTracking>(item));
                    }
                }
            }

            if (!command.PartitionProducts.IsNullOrEmpty())
            {
                foreach (var item in command.PartitionProducts)
                {
                    if (item.Tablets == 0 || item.Taps == 0)
                        return await Response.FailureAsync("Taps and Tablets Should not be 0");

                    var medicine = await _unitOfWork.Repository<PartitionMedicine>().GetItemOnAsync(i => i.Id == item.MedicineId);
                    if (medicine == null)
                    {
                        return await Response.FailureAsync(_localizer["MedicineNotFound"].Value);
                    }

                    if (!DateTime.TryParse(item.ExpireDate, out DateTime result))
                    {
                        return await Response.FailureAsync("ExpireDate Is Invalid Format");
                    }


                    var asd = result;

                    if (medicine.Tracking.Any(i => i.PurchasePrice == item.PurchasePriceForUnit && i.Taps == item.Taps && i.Tablets == item.Tablets && i.ExpireDate== result))
                    {
                        medicine.Tracking.
                            FirstOrDefault(i => i.PurchasePrice == item.PurchasePriceForUnit && i.Taps == item.Taps && i.Tablets == item.Tablets)!.TabletsAvailableAmount += item.TabletsAvailableAmount;
                    }
                    else
                    {
                        medicine.Tracking.Add(_mapper.Map<PartitionMedicineTracking>(item));
                    }
                }
            }

            await _unitOfWork.SaveAsync();
            return await Response.SuccessAsync(_localizer["Success"]);

        }
    }


}
