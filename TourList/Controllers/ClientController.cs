using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Client")]
  public class ClientController : BaseTourListController<IClientService, ClientDto>
  {
    public ClientController(IServiceInject service)
      : base(service.Clients)
    {
    }
  }
}