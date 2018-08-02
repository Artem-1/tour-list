using Microsoft.EntityFrameworkCore;
using System;
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
      Database.EnsureCreated();
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

    public void EditSub<T>(T dbEntity, Guid dbEntityId, T newEntity, Guid newEntityId) where T : class
    {
      if (dbEntity != null)
      {
        if (newEntity != null)
        {
          if (dbEntityId == newEntityId)
            // no relationship change, only scalar prop.
            Entry(dbEntity).CurrentValues.SetValues(newEntity);
          else
          {
            // Relationship change
            // Attach assumes that newEntity is an existing entity
            Attach(newEntity);
            dbEntity = newEntity;
          }
        }
        else // relationship has been removed
          dbEntity = null;
      }
      else
      {
        if (newEntity != null) // relationship has been added
        {
          // Attach assumes that newEntity is an existing entity
          Attach(newEntity);
          dbEntity = newEntity;
        }
        // else -> old and new entity is null -> nothing to do
      }
    }
  }
}
