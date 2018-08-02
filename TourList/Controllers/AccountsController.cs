using FastMapper.NetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TourList.Data;
using TourList.Dto;
using TourList.Model;
using TourList.UserOption;
using TourList.ViewModels;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Accounts")]
  public class AccountsController : Controller
  {
    private readonly TourListContext _appDbContext;

    public AccountsController(TourListContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody]LoginModel model)
    {
      User person = _appDbContext.Users.FirstOrDefault(x => x.EmailAddress == model.EmailAddress && x.Password == model.Password);

      if (person == null)
        return BadRequest("Invalid email address or password.");

      var identity = GetIdentity(model.EmailAddress);
      var encodedJwt = GenerateToken(identity);

      var response = new
      {
        token = encodedJwt,
        user = new { firstName = person.FirstName, lastName = person.LastName }
      };

      return Ok(response);
    }

    [HttpPost("reg")]
    public async Task<IActionResult> Register([FromBody]RegisterModel model)
    {
      // service getUserByEmail
      var user = _appDbContext.Users.SingleOrDefault(u => u.EmailAddress == model.EmailAddress);

      if (user != null)
        return BadRequest("user already exist with email address");

      //service add new user
      var userIdentity = TypeAdapter.Adapt<User>(model);
      userIdentity.Id = Guid.NewGuid();
      await _appDbContext.AddAsync(userIdentity);
      await _appDbContext.SaveChangesAsync();

      return Login(new LoginModel { EmailAddress = model.EmailAddress, Password = model.Password });
    }

    private string GenerateToken(ClaimsIdentity identity)
    {
      var now = DateTime.UtcNow;
      // создаем JWT-токен
      var jwt = new JwtSecurityToken(
              issuer: AuthOptions.ISSUER,
              audience: AuthOptions.AUDIENCE,
              notBefore: now,
              claims: identity.Claims,
              expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
              signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

      return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private ClaimsIdentity GetIdentity(string email)
    {
      var claims = new List<Claim>
      {
          new Claim(ClaimsIdentity.DefaultNameClaimType, email)
      };

      ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token",
          ClaimsIdentity.DefaultNameClaimType,
          ClaimsIdentity.DefaultRoleClaimType);

      return claimsIdentity;
    }
  }
}