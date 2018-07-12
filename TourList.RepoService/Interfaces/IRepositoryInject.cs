using System;

namespace TourList.Data.Interfaces
{
  public interface IRepositoryInject : IDisposable
  {
    ITourRepository Tours { get; }
    IClientRepository Clients { get; }
    IExcursionRepository Excursions { get; }
    IExcursionSightRepository ExcursionSights { get; }
    IUserRepository Users { get; }
    void Save();
  }
}
