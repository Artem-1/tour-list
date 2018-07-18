using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class SnapshotSightConfiguration : IEntityTypeConfiguration<SnapshotSight>
  {
    public void Configure(EntityTypeBuilder<SnapshotSight> builder)
    {
      builder
        .Property(u => u.Name)
        .HasMaxLength(100)
        .IsRequired();
    }
  }
}
