using Microsoft.AspNetCore.Mvc;
using TourList.Model;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Tour")]
  public class TourController : BaseTourListController<ITourRepository, Tour>
  {
    public TourController(ITourRepository dbTour)
      : base(dbTour)
    {
    }
  }
}