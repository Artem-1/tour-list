using FastMapper.NetCore;
using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;
using TourList.UserOption;
using TourList.ViewModels;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Accounts")]
  public class AccountsController : Controller
  {
    private IServiceInject _services;

    public AccountsController(IServiceInject services)
    {
      _services = services;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody]LoginModel model)
    {
      User person = TypeAdapter.Adapt<User>(_services.Users.Authentication(model.EmailAddress, model.Password));

      if (person == null)
        return BadRequest("Invalid email address or password.");

      var encodedJwt = AuthOptions.GenerateToken(model.EmailAddress);

      var response = new
      {
        token = encodedJwt,
        user = new { firstName = person.FirstName, lastName = person.LastName }
      };

      return Ok(response);
    }

    [HttpPost("reg")]
    public IActionResult Register([FromBody]RegisterModel model)
    {
      var newUser = _services.Users.Register(TypeAdapter.Adapt<UserDto>(model));

      if(newUser != null)
        return Login(new LoginModel { EmailAddress = newUser.EmailAddress, Password = newUser.Password });

      return BadRequest("user already exist with this email address");
    }
  }
}