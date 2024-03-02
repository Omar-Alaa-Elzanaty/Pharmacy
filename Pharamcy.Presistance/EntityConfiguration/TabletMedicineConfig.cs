using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharamcy.Domain.Models;

namespace Pharamcy.Presistance.EntityConfiguration
{
    internal class TabletMedicineConfig : IEntityTypeConfiguration<TabletMedicine>
    {
        public void Configure(EntityTypeBuilder<TabletMedicine> builder)
        {
            builder.Property(x => x.TabletPrice).HasColumnType("money");
            builder.Property(x => x.TapePrice).HasColumnType("money");
        }
    }
}
