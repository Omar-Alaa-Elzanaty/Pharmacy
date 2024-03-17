using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharamcy.Domain.Models;

namespace Pharamcy.Presistance.EntityConfiguration
{
    internal class PartitionMedicineTrackingConfig : IEntityTypeConfiguration<PartitionMedicineTracking>
    {
        public void Configure(EntityTypeBuilder<PartitionMedicineTracking> builder)
        {
        }
    }
}
