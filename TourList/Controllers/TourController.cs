using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/tour")]
  public class TourController : Controller
  {
    private IServiceInject _services;

    public TourController(IServiceInject services)
    {
      _services = services;
    }

    [Authorize]
    //[Route("getlogin")]
    // GET: api/tour
    [HttpGet]
    public IEnumerable<TourDto> Get()
    {
      return _services.Tours.GetAll();
    }

    // GET: api/tour/5
    [HttpGet("{id}")]
    public TourDto Get(Guid id)
    {
      return _services.Tours.Get(id);
    }

    // POST: api/tour
    [HttpPost]
    public void Post([FromBody]TourDto item)
    {            
      _services.Tours.Create(item);
    }

    // PUT: api/tour
    [HttpPut]
    public void Put([FromBody]TourDto item)
    {
      if (item.Excursion != null)
      {
        var ex = _services.Excursions.SetExcursion(item.Excursion.Name, item.Excursion.ExcursionSights);
        item.Excursion = _services.Excursions.Get(ex);
      }

      if (item.Client != null && item.Client.Id == Guid.Empty)
      {
        var cl = _services.Clients.SetClient(item.Client.Name);
        item.Client = _services.Clients.Get(cl);
      }

      _services.Tours.Edit(item);
    }
  }
}