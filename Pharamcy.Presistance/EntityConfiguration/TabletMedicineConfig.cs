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
    internal class TabletMedicineConfig : IEntityTypeConfiguration<PartitionMedicine>
    {
        public void Configure(EntityTypeBuilder<PartitionMedicine> builder)
        {
        }
    }
}
