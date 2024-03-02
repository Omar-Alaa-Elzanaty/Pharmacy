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
    internal class MedicalTypeConfig : IEntityTypeConfiguration<MedicalType>
    {
        public void Configure(EntityTypeBuilder<MedicalType> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
