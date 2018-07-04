using Microsoft.AspNetCore.Mvc;
using TourList.Model;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Excursion")]
  public class ExcursionController : BaseTourListController<IExcursionRepository, Excursion>
  {
    public ExcursionController(IExcursionRepository dbExcursion)
      : base(dbExcursion)
    {
    }
  }
}