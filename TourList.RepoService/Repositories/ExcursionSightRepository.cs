namespace TourList.RepoService.Repositories
{
  public class ExcursionSightRepository : BaseRepository<Model.ExcursionSight>, Interfaces.IExcursionSightRepository
  {
    public ExcursionSightRepository(TourListContext dbContext)
      : base(dbContext, dbContext.ExcursionSights)
    {
    }
  }
}
