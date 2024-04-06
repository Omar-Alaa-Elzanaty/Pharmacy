using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharamcy.Domain.Models;

namespace Pharamcy.Presistance.EntityConfiguration
{
    internal class SupplierPurchaseInvoiceConfig : IEntityTypeConfiguration<PurchaseInvoice>
    {
        public void Configure(EntityTypeBuilder<PurchaseInvoice> builder)
        {
            //builder.HasIndex(x=>x.ImportInvoiceNumber).IsUnique();
        }
    }
}
