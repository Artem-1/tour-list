﻿using Microsoft.AspNetCore.Mvc;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Excursion")]
  public class ExcursionController : BaseTourListController<IExcursionService, ExcursionDto>
  {
    public ExcursionController(IServiceInject service)
      : base(service.Excursions)
    {
    }

    // api/[controller]
    [HttpPost]
    [HttpPut]
    public void Set([FromBody]ExcursionDto item)
    {
      _service.Set(item.Name, item.ExcursionSights);
    }
  }
}