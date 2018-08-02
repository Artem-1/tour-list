using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TourList.Data;
using TourList.Helpers;
using TourList.UserOption;

namespace TourList
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors();
      services.AddMvc();
      services.AddEntityFrameworkSqlServer();

      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(AuthOptions.ConfigureOptions);

      string connection = Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<TourListContext>(options => options.UseSqlServer(connection));

      StartupHelper.ConfigureRepositories(services);
      StartupHelper.ConfigureServices(services);
      StartupHelper.AdapterConfig();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
        app.UseExceptionHandler();

      app.UseStatusCodePages();
      app.UseAuthentication();
      app.UseMvc();
    }
  }
}
