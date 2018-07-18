using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Excursion")]
  public class ExcursionController : Controller
  {
    private IServiceInject _services;

    public ExcursionController(IServiceInject services)
    {
      _services = services;
    }

    // GET: api/Excursion
    [HttpGet]
    public IEnumerable<ExcursionDto> Get()
    {
      return _services.Excursions.GetAll();
    }

    // GET: api/Excursion/5
    [HttpGet("{id}")]
    public ExcursionDto Get(Guid id)
    {
      return _services.Excursions.Get(id);
    }

    // POST: api/Excursion
    [HttpPost]
    public void Post([FromBody]ExcursionDto excursion)
    {
      _services.Excursions.SetExcursion(excursion.Name, excursion.ExcursionSights);
    }
  }
}