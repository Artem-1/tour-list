﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TourList.Data;
using TourList.Helpers;

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

      string connection = Configuration.GetConnectionString("DefaultConnection");
      services.AddDbContext<TourListContext>(options => options.UseSqlServer(connection));

      StartupHelper.ConfigureRepositories(services);
      StartupHelper.ConfigureServices(services);
      StartupHelper.AdapterConfig();
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
