namespace TourList.RepoService.Repositories
{
  public class TourRepository : BaseRepository<Model.Tour>, Interfaces.ITourRepository
  {
    public TourRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Tours)
    {
    }
  }
}
