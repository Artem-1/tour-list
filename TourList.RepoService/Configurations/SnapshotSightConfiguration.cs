using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class SnapshotSightConfiguration : IEntityTypeConfiguration<SnapshotSight>
  {
    public void Configure(EntityTypeBuilder<SnapshotSight> builder)
    {
      builder.HasKey(ss => ss.Id);

      builder.Property(ss => ss.Name)
        .HasMaxLength(100)
        .IsRequired();

      builder.HasOne(ss => ss.Tour)
        .WithMany(t => t.SnapshotSights)
        .HasForeignKey(ss => ss.TourId)
        .IsRequired();
    }
  }
}
