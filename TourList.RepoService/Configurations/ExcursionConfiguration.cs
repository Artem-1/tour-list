using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class ExcursionConfiguration : IEntityTypeConfiguration<Excursion>
  {
    public void Configure(EntityTypeBuilder<Excursion> builder)
    {
      builder.HasKey(e => e.Id);

      builder.Property(e => e.Name)
        .HasMaxLength(100)
        .IsRequired();
    }
  }
}
