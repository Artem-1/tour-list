using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Tour")]
  public class TourController : Controller
  {
    private IServiceInject _services;

    public TourController(IServiceInject serivces)
    {
      _services = serivces;
    }

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
      _services.Tours.Edit(item);
    }
  }
}