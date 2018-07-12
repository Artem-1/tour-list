using System;
using TourList.Data.Interfaces;

namespace TourList.Data.Repositories
{
  public class RepositoryInject : IRepositoryInject
  {
    private bool disposed = false;

    private readonly TourListContext _context;
    private ITourRepository _tours;
    private IClientRepository _clients;
    private IExcursionRepository _excursions;
    private IExcursionSightRepository _excursionSights;

    public ITourRepository Tours => 
      (_tours == null) ? new TourRepository(_context) : _tours;

    public IClientRepository Clients => 
      (_clients == null) ? new ClientRepository(_context) : _clients;
    
    public IExcursionRepository Excursions => 
      (_excursions == null) ? new ExcursionRepository(_context) : _excursions;

    public IExcursionSightRepository ExcursionSights => 
      (_excursionSights == null) ? new ExcursionSightRepository(_context) : _excursionSights;
    
    public RepositoryInject(TourListContext context)
    {
      _context = context;
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
