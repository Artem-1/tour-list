namespace TourList.RepoService.Repositories
{
  public class UserRepository : BaseRepository<Model.User>, Interfaces.IUserRepository
  {
    public UserRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Users)
    {
    }
  }
}
