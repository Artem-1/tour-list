using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/ExcursionSight")]
  public class ExcursionSightController : BaseTourListController<IExcursionSightService, ExcursionSightDto>
  {
    public ExcursionSightController(IExcursionSightService serivce)
      : base(serivce)
    {
    }
  }
}