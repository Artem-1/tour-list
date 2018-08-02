using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class ExcursionSightConfiguration : IEntityTypeConfiguration<ExcursionSight>
  {
    public void Configure(EntityTypeBuilder<ExcursionSight> builder)
    {
      builder.HasKey(es => es.Id);

      builder.Property(es => es.Name)
        .HasMaxLength(100)
        .IsRequired();

      builder.HasOne(es => es.Excursion)
        .WithMany(e => e.ExcursionSights)
        .HasForeignKey(es => es.ExcursionId)
        .IsRequired();
    }
  }
}
