using System;
using System.Collections.Generic;
using TourList.Model;

namespace TourList.Data.Interfaces
{
  public interface IExcursionRepository : IRepository<Excursion>
  {
    void AddSight(Guid idExcursion, Guid idSight);
    ICollection<ExcursionSight> GetExcursionSights(Guid idExcursion);
  }
}
