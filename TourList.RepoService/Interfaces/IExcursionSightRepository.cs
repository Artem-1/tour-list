using System.Collections.Generic;
using TourList.Model;

namespace TourList.Data.Interfaces
{
  public interface IExcursionSightRepository : IRepository<ExcursionSight>
  {
    void AddRange(IEnumerable<ExcursionSight> entities);
    void RemoveRange(IEnumerable<ExcursionSight> entities);
  }
}
