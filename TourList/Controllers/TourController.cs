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

    // POST: api/[controller]
    [HttpPost]
    public void Post([FromBody]TourDto item)
    {
      _service.Create(item);
    }

    // PUT: api/[controller]
    [HttpPut]
    public void Put([FromBody]TourDto item)
    {
      _service.Edit(item);
    }
  }
}