using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Tour")]
  public class TourController : BaseTourListController<ITourService, TourDto>
  {
    public TourController(IServiceInject serivce)
      : base(serivce.Tours)
    {
    }
  }
}