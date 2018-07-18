using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/User")]
  public class UserController : Controller
  {
    public UserController(IServiceInject service)
    {
    }
  }
}