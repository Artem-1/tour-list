namespace TourList.Service.Interfaces
{
  public interface IServiceInject
  {
    ITourService Tours { get; }
    IClientService Clients { get; }
    IExcursionService Excursions { get; }
    IExcursionSightService ExcursionSights { get; }
    IUserService Users { get; }
  }
}
