﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourList.Model;

namespace TourList.Data.Configurations
{
  class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(u => u.Id);

      builder.Property(u => u.FirstName)
        .HasMaxLength(100)
        .IsRequired();

      builder.Property(u => u.LastName)
        .HasMaxLength(100);

      builder.Property(u => u.EmailAddress)
        .HasMaxLength(100)
        .IsRequired();

      builder.Property(u => u.Password)
        .HasMaxLength(20)
        .IsRequired();
    }
  }
}
