using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class TourConfiguration : IEntityTypeConfiguration<Tour>
  {
    public void Configure(EntityTypeBuilder<Tour> builder)
    {
      builder.HasKey(t => t.Id);

      builder.Property(t => t.Date)
        .IsRequired();

      builder.HasOne(t => t.Excursion)
        .WithMany(e => e.Tours)
        .HasForeignKey(t => t.ExcursionId)
        .IsRequired();

      builder.HasOne(t => t.Client)
        .WithMany(c => c.Tours)
        .HasForeignKey(t => t.ClientId)
        .IsRequired();
    }
  }
}
