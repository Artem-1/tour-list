using FastMapper.NetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TourList.Data.Interfaces;
using TourList.Data.Repositories;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Implementation;
using TourList.Service.Interfaces;

namespace TourList.Helpers
{
  public static class StartupHelper
  {
    public static void ConfigureRepositories(IServiceCollection services)
    {
      services.AddScoped<IRepositoryInject, RepositoryInject>();

      services.AddScoped<IClientRepository, ClientRepository>();
      services.AddScoped<IExcursionRepository, ExcursionRepository>();
      services.AddScoped<ITourRepository, TourRepository>();
      services.AddScoped<IExcursionSightRepository, ExcursionSightRepository>();
      services.AddScoped<ISnapshotSightRepository, SnapshotSightRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<IServiceInject, ServiceInject>();
      services.AddScoped<IClientService, ClientService>();
      services.AddScoped<IExcursionService, ExcursionService>();
      services.AddScoped<IExcursionSightService, ExcursionSightService>();
      services.AddScoped<ITourService, TourService>();
      services.AddScoped<IUserService, UserService>();
    }

    public static void AdapterConfig()
    {
      TypeAdapterConfig<Tour, TourDto>.NewConfig().MaxDepth(1);
      TypeAdapterConfig<Excursion, ExcursionDto>.NewConfig().MaxDepth(1);
      TypeAdapterConfig<IEnumerable<Tour>, IEnumerable<TourDto>>.NewConfig().MaxDepth(1);
    }
  }
}
