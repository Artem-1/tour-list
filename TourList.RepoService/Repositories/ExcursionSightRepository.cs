using System.Collections.Generic;
using TourList.Model;

namespace TourList.Data.Repositories
{
  public class ExcursionSightRepository : BaseRepository<ExcursionSight>, Interfaces.IExcursionSightRepository
  {
    public ExcursionSightRepository(TourListContext dbContext)
      : base(dbContext)
    {
    }

    public void AddRange(IEnumerable<ExcursionSight> entities)
    {
      DbContext.AddRange(entities);
    }

    public void RemoveRange(IEnumerable<ExcursionSight> entities)
    {
      DbContext.RemoveRange(entities);
    }
  }
}
