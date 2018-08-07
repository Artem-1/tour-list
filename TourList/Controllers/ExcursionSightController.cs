using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/ExcursionSight")]
  public class ExcursionSightController : Controller
  {
    private IServiceInject _services;

    public ExcursionSightController(IServiceInject services)
    {
      _services = services;
    }
    // GET: api/ExcursionSight
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return _services.ExcursionSights.GetNames();
    }

    // GET: api/ExcursionSight/5
    [HttpGet("{id}")]
    public ExcursionSightDto Get(Guid id)
    {
      return _services.ExcursionSights.Get(id);
    }
  }
}
