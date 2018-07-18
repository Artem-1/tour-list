using System;
using System.Collections.Generic;

namespace TourList.Data.Interfaces
{
  public interface IRepository<TEntity>
  {
    IEnumerable<TEntity> GetAll();
    TEntity GetEntity(Guid id);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(Guid id);
  }
}
