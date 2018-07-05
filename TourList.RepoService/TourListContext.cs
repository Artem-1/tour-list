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
    public DbSet<TourClient> TourClients { get; set; }
    public DbSet<TourExcursion> TourExcursions { get; set; }
    public DbSet<ExcursionSight> ExcursionSights { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      // drop config inside config file
      optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=tourlistdb;Trusted_Connection=True;MultipleActiveResultSets=true");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().Property(b => b.EmailAddress).IsRequired();

      //tourClient
      modelBuilder.Entity<TourClient>()
            .HasKey(t => new { t.TourId, t.ClientId });

      modelBuilder.Entity<TourClient>()
          .HasOne(tc => tc.Tour)
          .WithMany(t => t.TourClients)
          .HasForeignKey(tc => tc.TourId);

      modelBuilder.Entity<TourClient>()
          .HasOne(tc => tc.Client)
          .WithMany(c => c.TourClients)
          .HasForeignKey(tc => tc.ClientId);

      //tourExcurtion
      modelBuilder.Entity<TourExcursion>()
            .HasKey(t => new { t.TourId, t.ExcursionId });

      modelBuilder.Entity<TourExcursion>()
          .HasOne(te => te.Tour)
          .WithMany(t => t.TourExcursions)
          .HasForeignKey(tc => tc.TourId);

      modelBuilder.Entity<TourExcursion>()
          .HasOne(te => te.Excursion)
          .WithMany(e => e.TourExcursions)
          .HasForeignKey(te => te.ExcursionId);
    }
  }
}
