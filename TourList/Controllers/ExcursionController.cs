using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Model;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Excursion")]
  public class ExcursionController : BaseTourListController<IExcursionRepository, ExcursionDto>
  {
    public ExcursionController(IExcursionRepository dbExcursion)
      : base(dbExcursion)
    {
    }
  }
}