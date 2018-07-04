using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  public class BaseTourListController<TIRepo, TEntity> : Controller
    where TIRepo : IRepository<TEntity>
    where TEntity : class
  {
    protected TIRepo _dbEntity;

    public BaseTourListController(TIRepo dbEntity)
    {
      _dbEntity = dbEntity;
    }

    // GET: api/[Entity]
    [HttpGet]
    public IEnumerable<TEntity> Get()
    {
      return _dbEntity.GetList();
    }

    // GET: api/[Entity]/5
    [HttpGet("{id}")]
    public TEntity Get(Guid id)
    {
      return _dbEntity.GetEntity(id);
    }

    // POST: api/[Entity]
    [HttpPost]
    public void Post([FromBody]TEntity item)
    {
      _dbEntity.Update(item);
    }

    // PUT: api/[Entity]
    [HttpPut]
    public void Put([FromBody]TEntity item)
    {
      _dbEntity.Create(item);
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(Guid id)
    {
      _dbEntity.Delete(id);
    }
  }
}