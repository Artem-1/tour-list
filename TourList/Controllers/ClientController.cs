using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TourList.Dto;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Client")]
  public class ClientController : Controller
  {
    private IServiceInject _services;

    public ClientController(IServiceInject services)
    {
      _services = services;
    }

    // GET: api/Client
    [HttpGet]
    public IEnumerable<ClientDto> Get()
    {
      return _services.Clients.GetAll();
    }

    // GET: api/Client/5
    [HttpGet("{id}")]
    public ClientDto Get(Guid id)
    {
      return _services.Clients.Get(id);
    }

    // POST: api/Client
    [HttpPost]
    public void Post([FromBody]string name)
    {
      _services.Clients.SetClient(name);
    }
  }
}
