using System;
using TourList.Data.Interfaces;

namespace TourList.Data.Repositories
{
  public class RepositoryInject : IRepositoryInject
  {
    private bool disposed = false;

    private readonly TourListContext _context;

    public ITourRepository Tours { get; }
    public IClientRepository Clients { get; }
    public IExcursionRepository Excursions { get; }
    public IExcursionSightRepository ExcursionSights { get; }
    public ISnapshotSightRepository SnapshotSights { get; }
    public IUserRepository Users { get; }

    public RepositoryInject(TourListContext context,
                            ITourRepository tours,
                            IClientRepository clients,
                            IExcursionRepository excursions,
                            IExcursionSightRepository excursionSights,
                            ISnapshotSightRepository snapshotSights,
                            IUserRepository users)
    {
      _context = context;
      Tours = tours;
      Clients = clients;
      Excursions = excursions;
      ExcursionSights = excursionSights;
      SnapshotSights = snapshotSights;
      Users = users;
    }

    public void Save()
    {
      _context.SaveChanges();
    }

    public virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        if (disposing)
        {
          _context.Dispose();
        }
      }
      disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
