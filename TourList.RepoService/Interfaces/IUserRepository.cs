using TourList.Model;

namespace TourList.Data.Interfaces
{
  public interface IUserRepository : IRepository<User>
  {
    User FindByEmail(string email);
    User Authentication(string email, string password);
  }
}
