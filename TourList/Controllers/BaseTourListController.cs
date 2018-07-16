using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  public class BaseTourListController<TService, TDto> : Controller
    where TService : IService<TDto>
  {
    protected TService _service;

    public BaseTourListController(TService service)
    {
      _service = service;
    }

    // GET: api/[controller]
    [HttpGet]
    public IEnumerable<TDto> Get()
    {
      return _service.GetAll();
    }

    // GET: api/[controller]/5
    [HttpGet("{id}")]
    public TDto Get(Guid id)
    {
      return _service.Get(id);
    }
  }
}