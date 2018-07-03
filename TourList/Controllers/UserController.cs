using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TourList.Model;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  // [Route("api/[controller]")]
  [Produces("application/json")]
  [Route("api/User")]
  public class UserController : Controller
  {
    private IUserRepository _dbUser;

    public UserController(IUserRepository dbUser)
    {
      _dbUser = dbUser;
    }

    // GET: api/User
    [HttpGet]
    public IEnumerable<User> Get()
    {
      return _dbUser.GetList();
    }

    // GET: api/User/5
    [HttpGet("{id}", Name = "Get")]
    public User Get(Guid id)
    {
      return _dbUser.GetEntity(id);
    }

    // POST: api/User
    [HttpPost]
    public void Post([FromBody]User item)
    {
      _dbUser.Update(item);
    }

    // PUT: api/User
    [HttpPut]
    public void Put([FromBody]User item)
    {
      item.Id = Guid.NewGuid();
      _dbUser.Create(item);
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
      _dbUser.Delete(id);
    }
  }
}
