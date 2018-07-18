using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class TourConfiguration : IEntityTypeConfiguration<Tour>
  {
    public void Configure(EntityTypeBuilder<Tour> builder)
    {
      builder
        .Property(u => u.Date)
        .IsRequired();
    }
  }
}
