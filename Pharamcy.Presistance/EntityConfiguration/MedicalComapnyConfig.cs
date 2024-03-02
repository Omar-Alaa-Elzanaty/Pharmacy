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
    internal class MedicalComapnyConfig : IEntityTypeConfiguration<MedicalCompany>
    {
        public void Configure(EntityTypeBuilder<MedicalCompany> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
        }
    }
}
