using TourList.Data.Interfaces;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class ServiceInject : IServiceInject
  {
    private IRepositoryInject _repository;

    private readonly ITourService _tours;
    private readonly IClientService _clients;
    private readonly IExcursionService _excursions;
    private readonly IExcursionSightService _excursionSights;
    private readonly IUserService _users;

    public ITourService Tours =>
      (_tours == null) ? new TourService(_repository) : _tours;

    public IClientService Clients =>
      (_clients == null) ? new ClientService(_repository) : _clients;

    public IExcursionService Excursions =>
      (_excursions == null) ? new ExcursionService(_repository) : _excursions;

    public IExcursionSightService ExcursionSights =>
      (_excursionSights == null) ? new ExcursionSightService(_repository) : _excursionSights;

    public IUserService Users =>
      (_excursionSights == null) ? new UserService(_repository) : _users;

    public ServiceInject(IRepositoryInject repository)
    {
      _repository = repository;
    }
  }
}
