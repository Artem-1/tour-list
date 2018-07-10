using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TourList.Data;
using TourList.Data.Interfaces;
using TourList.Data.Repositories;
using TourList.Service.Interfaces;
using TourList.Service.Implementation;

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

      services.AddScoped<TourListContext>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IClientRepository, ClientRepository>();
      services.AddScoped<ITourRepository, TourRepository>();
      services.AddScoped<IExcursionRepository, ExcursionRepository>();
      services.AddScoped<IExcursionSightRepository, ExcursionSightRepository>();

      services.AddScoped<ITourService, TourService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseCors(builder => builder.AllowAnyOrigin());

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();
    }
  }
}
