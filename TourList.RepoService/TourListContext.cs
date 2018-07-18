using Microsoft.EntityFrameworkCore;
using TourList.Data.Configurations;
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

    public TourListContext(DbContextOptions<TourListContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new ClientConfiguration());
      modelBuilder.ApplyConfiguration(new ExcursionConfiguration());
      modelBuilder.ApplyConfiguration(new TourConfiguration());
      modelBuilder.ApplyConfiguration(new ExcursionSightConfiguration());
      modelBuilder.ApplyConfiguration(new SnapshotSightConfiguration());
      modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
  }
}
