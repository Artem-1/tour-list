using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class ExcursionSightConfiguration : IEntityTypeConfiguration<ExcursionSight>
  {
    public void Configure(EntityTypeBuilder<ExcursionSight> builder)
    {
      builder
        .Property(u => u.Name)
        .HasMaxLength(100)
        .IsRequired();
    }
  }
}
