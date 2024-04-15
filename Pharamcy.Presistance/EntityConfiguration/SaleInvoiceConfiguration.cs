using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharamcy.Application.Features.SaleInvoice.Commands.SaveSaleInvoceCommand;
using Pharamcy.Domain.Models;

namespace Pharamcy.Presistance.EntityConfiguration
{
    internal class SaleInvoiceConfiguration : IEntityTypeConfiguration<SalesInvoice>
    {
        public void Configure(EntityTypeBuilder<SalesInvoice> builder)
        {
            builder.HasOne(x => x.Client)
                .WithMany(x=>x.Invoices)
                .HasForeignKey(x => x.ClientId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
