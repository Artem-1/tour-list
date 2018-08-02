using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class ClientConfiguration : IEntityTypeConfiguration<Client>
  {
    public void Configure(EntityTypeBuilder<Client> builder)
    {
      builder.HasKey(c => c.Id);

      builder.Property(c => c.Name)
        .HasMaxLength(100)
        .IsRequired();
    }
  }
}
