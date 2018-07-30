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

    [HttpPost("/login")]
    public async Task Login([FromBody]LoginModel model)
    {
      var encodedJwt = GenerateToken(model);

      var response = new
      {
        access_token = encodedJwt,
        username = model.EmailAddress
      };

      // сериализация ответа
      Response.ContentType = "application/json";
      await Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
    }

    [HttpPost("/reg")]
    public async Task<IActionResult> Register([FromBody]RegisterModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var userIdentity = TypeAdapter.Adapt<User>(model);

      var user = _appDbContext.Users.SingleOrDefault(u => u.EmailAddress == model.EmailAddress);

      if (user != null)
        BadRequest();

      userIdentity.Id = Guid.NewGuid();
      await _appDbContext.AddAsync(userIdentity);
      await _appDbContext.SaveChangesAsync();

      return new OkObjectResult("Account created");
    }

    //public Task Logout()
    //{
    //  //new JwtBearerChallengeContext()
    //}

    private async Task<string> GenerateToken(LoginModel model)
    {
      var identity = GetIdentity(model.EmailAddress, model.Password);

      if (identity == null)
      {
        Response.StatusCode = 400;
        await Response.WriteAsync("Invalid username or password.");
        return null;
      }

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

    private ClaimsIdentity GetIdentity(string email, string password)
    {
      User person = _appDbContext.Users.FirstOrDefault(x => x.EmailAddress == email && x.Password == password);
      if (person != null)
      {
        var claims = new List<Claim>
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType, person.EmailAddress)
        };

        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token",
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
      }

      // если пользователя не найдено
      return null;
    }
  }
}