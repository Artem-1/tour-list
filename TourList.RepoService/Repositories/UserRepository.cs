using System.Linq;
using TourList.Model;

namespace TourList.Data.Repositories
{
  public class UserRepository : BaseRepository<User>, Interfaces.IUserRepository
  {
    public UserRepository(TourListContext dbContext)
      : base(dbContext)
    {
    }

    public User FindByEmail(string email)
    {
      return DbContext.Users.SingleOrDefault(x => x.EmailAddress == email);
    }

    public User Authentication(string email, string password)
    {
      return DbContext.Users.SingleOrDefault(x => x.EmailAddress == email && x.Password == password);
    }
  }
}
