using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder
        .Property(u => u.FirstName)
        .HasMaxLength(100)
        .IsRequired();

      builder
        .Property(u => u.EmailAddress)
        .HasMaxLength(100)
        .IsRequired();

      builder
        .Property(u => u.Password)
        .HasMaxLength(100)
        .IsRequired();
    }
  }
}
