using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/excursion")]
  public class ExcursionController : Controller
  {
    private IServiceInject _services;

    public ExcursionController(IServiceInject services)
    {
      _services = services;
    }

    // GET: api/Excursion
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return _services.Excursions.GetNames();
    }

    // GET: api/Excursion/sights
    [Route("/{name}")]
    [HttpGet("{name}")]
    public IActionResult Get(string name)
    {
      var sights = _services.Excursions.GetSights(name);
      return Ok(sights);
    }

    // POST: api/Excursion
    [HttpPost]
    public Guid Post([FromBody]ExcursionDto excursion)
    {
      return _services.Excursions.SetExcursion(excursion.Name, excursion.ExcursionSights);
    }
  }
}