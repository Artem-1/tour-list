using TourList.Model;

namespace TourList.Data.Repositories
{
  public class UserRepository : BaseRepository<User>, Interfaces.IUserRepository
  {
    public UserRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Users)
    {
    }
  }
}
