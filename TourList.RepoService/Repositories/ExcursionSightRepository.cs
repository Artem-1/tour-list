using System.Collections.Generic;
using TourList.Model;

namespace TourList.Data.Repositories
{
  public class ExcursionSightRepository : BaseRepository<ExcursionSight>, Interfaces.IExcursionSightRepository
  {
    public ExcursionSightRepository(TourListContext dbContext)
      : base(dbContext, dbContext.ExcursionSights)
    {
    }

    public void AddRange(IEnumerable<ExcursionSight> entities)
    {
      _dbSet.AddRange(entities);
    }

    public void RemoveRange(IEnumerable<ExcursionSight> entities)
    {
      _dbSet.RemoveRange(entities);
    }
  }
}
