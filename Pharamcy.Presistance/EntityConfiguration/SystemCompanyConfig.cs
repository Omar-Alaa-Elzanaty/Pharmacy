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
    internal class SystemCompanyConfig : IEntityTypeConfiguration<SystemMedicalCompany>
    {
        public void Configure(EntityTypeBuilder<SystemMedicalCompany> builder)
        {
            builder.HasKey(x => x.Name);
        }
    }
}
