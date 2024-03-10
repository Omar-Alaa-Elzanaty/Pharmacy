using Mapster;
using Pharamcy.Application.Features.SupplierPurchases.Commands.SavePurchaseCommand;
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
        }
    }
}
