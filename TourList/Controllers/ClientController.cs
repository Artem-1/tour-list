using Microsoft.AspNetCore.Mvc;
using TourList.Model;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Client")]
  public class ClientController : BaseTourListController<IClientRepository, Client>
  {
    public ClientController(IClientRepository dbClient)
      : base(dbClient)
    {
    }
  }
}