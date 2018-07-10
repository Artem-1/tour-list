using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/User")]
  public class UserController //: BaseTourListController<IUserService, UserDto>
  {
    //public UserController(IUserRepository dbUser)
    //  :base(dbUser)
    //{
    //}
  }
}