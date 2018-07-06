using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  public class BaseTourListController<TIRepo, TEntityDto> : Controller
    where TIRepo : IRepository<TEntityDto>
    where TEntityDto : class
  {
    protected TIRepo _dbEntity;

    public BaseTourListController(TIRepo dbEntity)
    {
      _dbEntity = dbEntity;
    }

    // GET: api/[Entity]
    [HttpGet]
    public IEnumerable<TEntityDto> Get()
    {
      return _dbEntity.GetAll();
    }

    // GET: api/[Entity]/5
    [HttpGet("{id}")]
    public TEntityDto Get(Guid id)
    {
      return _dbEntity.GetEntity(id);
    }

    // POST: api/[Entity]
    [HttpPost]
    public void Post([FromBody]TEntityDto item)
    {
      _dbEntity.Create(item);
    }

    // PUT: api/[Entity]
    [HttpPut]
    public void Put([FromBody]TEntityDto item)
    {
      _dbEntity.Update(item);
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
      _dbEntity.Delete(id);
    }
  }
}