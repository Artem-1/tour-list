using System;
using System.Collections.Generic;

namespace TourList.Data
{
  public abstract class BaseRepository<TEntity> : Interfaces.IRepository<TEntity>
    where TEntity : class
  {
    public TourListContext DbContext { get; }

    public BaseRepository(TourListContext context)
    {
      DbContext = context;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
      return DbContext.Set<TEntity>();
    }

    public virtual TEntity GetEntity(Guid id)
    {
      return DbContext.Find<TEntity>(id);
    }

    public void Create(TEntity entity)
    {
      DbContext.Add(entity);
    }

    public void Update(TEntity entity)
    {
      DbContext.Update(entity);
    }

    public void Delete(Guid id)
    {
      TEntity entity = GetEntity(id);
      if (entity != null)
        DbContext.Remove(entity);
    }
  }
}
