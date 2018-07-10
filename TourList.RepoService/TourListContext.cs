using Microsoft.EntityFrameworkCore;
using TourList.Model;

namespace TourList.Data
{
  public class TourListContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Excursion> Excursions { get; set; }
    public DbSet<SnapshotSight> SnapshotSights { get; set; }
    public DbSet<ExcursionSight> ExcursionSights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // drop config inside config file
      optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=tourlistdb;Trusted_Connection=True;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().Property(b => b.EmailAddress).IsRequired();
      modelBuilder.Entity<User>().Property(b => b.FirstName).IsRequired();
      modelBuilder.Entity<User>().Property(b => b.Password).IsRequired();

      modelBuilder.Entity<Tour>()
        .Property(u => u.Date)
        .IsRequired();

      modelBuilder.Entity<Client>()
        .Property(u => u.Name)
        .HasMaxLength(100)
        .IsRequired();

      modelBuilder.Entity<Excursion>()
        .Property(u => u.Name)
        .HasMaxLength(100)
        .IsRequired();

      modelBuilder.Entity<ExcursionSight>()
        .Property(u => u.Name)
        .HasMaxLength(100)
        .IsRequired();

      modelBuilder.Entity<SnapshotSight>()
        .Property(u => u.Name)
        .HasMaxLength(100)
        .IsRequired();
    }
  }
}
