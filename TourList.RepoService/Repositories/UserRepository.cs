using TourList.Model;
using TourList.Dto;

namespace TourList.RepoService.Repositories
{
  public class UserRepository : BaseRepository<User, UserDto>, Interfaces.IUserRepository
  {
    public UserRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Users)
    {
    }

    protected override UserDto GetDto(User entity)
    {
      return new UserDto()
      {
      };
    }

    protected override User GetModel(UserDto entity)
    {
      throw new System.NotImplementedException();
    }
  }
}
