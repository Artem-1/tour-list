using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/client")]
  public class ClientController : Controller
  {
    private IServiceInject _services;

    public ClientController(IServiceInject services)
    {
      _services = services;
    }

    // GET: api/client
    [HttpGet]
    public IEnumerable<string> Get()
    {
      return _services.Clients.GetNames();
    }

    // GET: api/client/5
    [HttpGet("{id}")]
    public ClientDto Get(Guid id)
    {
      return _services.Clients.Get(id);
    }

    // POST: api/client
    [HttpPost]
    public Guid Post([FromBody]ClientDto client)
    {
      return _services.Clients.SetClient(client.Name);
    }
  }
}
