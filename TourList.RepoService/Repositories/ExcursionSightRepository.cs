using TourList.Model;

namespace TourList.Data.Repositories
{
  public class ExcursionSightRepository : BaseRepository<ExcursionSight>, Interfaces.IExcursionSightRepository
  {
    public ExcursionSightRepository(TourListContext dbContext)
      : base(dbContext, dbContext.ExcursionSights)
    {
    }
  }
}
