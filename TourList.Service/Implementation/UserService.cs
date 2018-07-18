using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class UserService : IUserService
  {
    public UserService(IRepositoryInject repository)
    {
    }
  }
}
