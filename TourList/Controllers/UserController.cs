using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/User")]
  public class UserController : BaseTourListController<IUserService, UserDto>
  {
    public UserController(IServiceInject service)
      : base(service.Users)
    {
    }
  }
}