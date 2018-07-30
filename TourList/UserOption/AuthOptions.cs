using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TourList.UserOption
{
  public class AuthOptions
  {
    public const string ISSUER = "MyAuthServer"; // издатель токена
    public const string AUDIENCE = "localhost"; // потребитель токена
    public const int LIFETIME = 1; // время жизни токена - 1 минута

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
  }
}
