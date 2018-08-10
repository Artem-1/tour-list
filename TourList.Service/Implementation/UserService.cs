using FastMapper.NetCore;
using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class UserService : IUserService
  {
    private readonly IRepositoryInject _uow;

    public UserService(IRepositoryInject repository)
    {
      _uow = repository;
    }

    public UserDto Authentication(string email, string password)
    {
      var user = _uow.Users.Authentication(email, password);

      if (user == null)
        return null;

      return TypeAdapter.Adapt<UserDto>(user);
    }

    public UserDto Register(UserDto newUser)
    {
      var user = _uow.Users.FindByEmail(newUser.EmailAddress);

      if (user != null)
        return null;

      _uow.Users.Create(TypeAdapter.Adapt<User>(newUser));
      _uow.Save();

      var createdUser = _uow.Users.FindByEmail(newUser.EmailAddress);
      return TypeAdapter.Adapt<UserDto>(createdUser);
    }
  }
}
