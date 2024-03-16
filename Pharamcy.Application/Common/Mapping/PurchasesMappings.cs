using Mapster;
using Pharamcy.Application.Features.SupplierPurchases.Commands.SavePurchaseCommand;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetNextSupplierInvoiceByPharmacyId;
using Pharamcy.Application.Features.SupplierPurchases.Queries.GetPrevioudInvoiceByPharmacyId;
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


            config.NewConfig<PurchaseInvoice, GetPreviousInvoiceByPharmacyIdQueryDto>()
                .Map(i=>i.Items,i=>i.Items);


            config.NewConfig<PurchaseInvoiceItem, GetPreviousInvoiceItemsByPharmacyIdQueryDto>();

            config.NewConfig<PurchaseInvoice, GetNextInvoiceByPharmacyIdQueryDto>();
            config.NewConfig<PurchaseInvoiceItem, GetNextInvoiceItemsByPharmacyIdQueryDto>();

           
        }
    }
}
