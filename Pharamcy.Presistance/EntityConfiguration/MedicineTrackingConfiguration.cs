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
    internal class MedicineTrackingConfiguration : IEntityTypeConfiguration<MedicineTracking>
    {
        public void Configure(EntityTypeBuilder<MedicineTracking> builder)
        {
            builder.HasKey(x => new { x.Id, x.PharmacyId });
        }
    }
}
