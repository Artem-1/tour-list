using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IUserService
  {
    UserDto Authentication(string email, string password);
    UserDto Register(UserDto newUser);
  }
}
