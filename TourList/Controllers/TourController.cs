﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TourList.Dto;
using TourList.Model;
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
    [HttpGet] // GET: api/tour
    public IActionResult Get()
    {
      var tours = _services.Tours.GetAll();

      if (tours != null)
        return Ok(tours);
      else
        return BadRequest("server couldn't get tours");
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