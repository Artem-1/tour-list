using System;
using TourList.Data.Interfaces;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class SnapshotSightService : ISnapshotSightService
  {
    private ISnapshotSightRepository _snapshotSights;

    public SnapshotSightService(IRepositoryInject repository)
    {
      _snapshotSights = repository.SnapshotSights;
    }

    public Guid Create(string name, Guid tourId)
    {
      var snapshot = new Model.SnapshotSight() { Id = Guid.NewGuid(), Name = name, TourId = tourId };
      _snapshotSights.Create(snapshot);
      return snapshot.Id;
    }
  }
}
