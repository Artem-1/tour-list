using Microsoft.EntityFrameworkCore;
using TourList.Model;

namespace TourList.RepoService
{
  public class TourListContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Tour> Tours { get; set; }
    public DbSet<Excursion> Excursions { get; set; }
    public DbSet<TourExcursion> TourExcursions { get; set; }
    public DbSet<ExcursionSight> ExcursionSights { get; set; }

    public TourListContext(DbContextOptions<TourListContext> options)
      : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().Property(b => b.EmailAddress).IsRequired();
    }
  }
}
