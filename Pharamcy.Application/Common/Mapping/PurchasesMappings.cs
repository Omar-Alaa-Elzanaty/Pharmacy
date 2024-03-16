using Mapster;
using Pharamcy.Application.Features.SupplierPurchases.Commands.SavePurchaseCommand;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetNextSupplierInvoiceByPharmacyId;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetPrevioudInvoiceByPharmacyId;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetPurchaseInvoiceByImportInvoiceNumber;
using Pharamcy.Domain.Models;

namespace Pharamcy.Application.Common.Mapping
{
    public class PurchasesMappings : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Product, MedicineTracking>().
             Map(i => i.Amount, i => i.RealAmount).
             Map(i=>i.PurchasePrice,i=>i.PurchasePriceForUnit).
             Map(i=>i.SalePrice,i=>i.SalePriceForUnit); 

            config.NewConfig<PartitionProduct,PartitionMedicineTracking>().
             Map(i => i.PurchasePrice, i => i.PurchasePriceForUnit).
             Map(i => i.SalePrice, i => i.SalePriceForUnit).
             Map(i=>i.TabletsAvailableAmount,i=>i.TabletsAvailableAmount);

            config.NewConfig<SavePurchaseCommand, PurchaseInvoice>();

            config.NewConfig<PurchaseInvoice, GetPreviousInvoiceByPharmacyIdQueryDto>();
            config.NewConfig<PurchaseInvoiceItem, GetPreviousInvoiceItemsByPharmacyIdQueryDto>();

            config.NewConfig<PurchaseInvoice, GetNextInvoiceByPharmacyIdQueryDto>();
            config.NewConfig<PurchaseInvoiceItem, GetNextInvoiceItemsByPharmacyIdQueryDto>();

            config.NewConfig<PurchaseInvoice, GetPurchaseInvoiceByImportInvoiceNumberQueryDto>();
            config.NewConfig<PurchaseInvoiceItem, GetPurchaseInvoiceItemsByImportInvoiceNumberQueryDto>();
        }
    }
}
