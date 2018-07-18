using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class ServiceInject : IServiceInject
  {
    public ITourService Tours { get; }
    public IClientService Clients { get; }
    public IExcursionService Excursions { get; }
    public IExcursionSightService ExcursionSights { get; }
    public IUserService Users { get; }

    public ServiceInject(ITourService tours,
                         IClientService clients,
                         IExcursionService excursions,
                         IExcursionSightService excursionSights,
                         IUserService users)
    {
      Tours = tours;
      Clients = clients;
      Excursions = excursions;
      ExcursionSights = excursionSights;
      Users = users;
    }
  }
}
