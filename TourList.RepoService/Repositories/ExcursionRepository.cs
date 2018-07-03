namespace TourList.RepoService.Repositories
{
  public class ExcursionRepository : BaseRepository<Model.Excursion>, Interfaces.IExcursionRepository
  {
    public ExcursionRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Excursions)
    {
    }
  }
}
