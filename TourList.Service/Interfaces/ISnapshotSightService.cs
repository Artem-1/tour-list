using System;

namespace TourList.Service.Interfaces
{
  public interface ISnapshotSightService
  {
    Guid Create(string name, Guid tourId);
  }
}
