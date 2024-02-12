using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharamcy.Domain.Models;

namespace Pharamcy.Presistance.EntityConfiguration
{
    internal class MedicineRefernceConfigurations : IEntityTypeConfiguration<MedicineReference>
    {
        public void Configure(EntityTypeBuilder<MedicineReference> builder)
        {
            builder.HasKey(x => x.Name);
        }
    }
}
