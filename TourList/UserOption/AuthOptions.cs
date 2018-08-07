using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TourList.UserOption
{
  public class AuthOptions
  {
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "localhost"; // потребитель токена
    public const int LIFETIME = 1000; // время жизни токена - 1 минута

    private const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
      return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }

    public static void ConfigureOptions(JwtBearerOptions options)
    {
      options.RequireHttpsMetadata = false;
      options.TokenValidationParameters = new TokenValidationParameters
      {
        // укзывает, будет ли валидироваться издатель при валидации токена
        ValidateIssuer = true,
        // строка, представляющая издателя
        ValidIssuer = ISSUER,

        // будет ли валидироваться потребитель токена
        ValidateAudience = true,
        // установка потребителя токена
        ValidAudience = AUDIENCE,
        // будет ли валидироваться время существования
        ValidateLifetime = true,

        // установка ключа безопасности
        IssuerSigningKey = GetSymmetricSecurityKey(),
        // валидация ключа безопасности
        ValidateIssuerSigningKey = true,
      };
    }

    public static string GenerateToken(string email)
    {
      ClaimsIdentity identity = GetIdentity(email);
      var now = DateTime.UtcNow;
      
      // создаем JWT-токен
      var jwt = new JwtSecurityToken(
              issuer: ISSUER,
              audience: AUDIENCE,
              notBefore: now,
              claims: identity.Claims,
              expires: now.Add(TimeSpan.FromMinutes(LIFETIME)),
              signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

      return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private static ClaimsIdentity GetIdentity(string email)
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
