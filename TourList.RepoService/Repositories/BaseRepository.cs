using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TourList.Data
{
  public abstract class BaseRepository<TEntity> : Interfaces.IRepository<TEntity>
    where TEntity: class
  {
    protected TourListContext _dbContext;
    protected DbSet<TEntity> _dbSet;
    
    public BaseRepository(TourListContext context, DbSet<TEntity> dbSet)
    {
      _dbContext = context;
      _dbSet = dbSet;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
      return _dbSet;
    }

    public virtual TEntity GetEntity(Guid id)
    {
      return _dbSet.Find(id);
    }

    public IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate)
    {
      return _dbSet.Where(predicate).ToList();
    }

    public void Create(TEntity entity)
    {
      _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(Guid id)
    {
      TEntity entity = _dbSet.Find(id);
      if (entity != null)
        _dbSet.Remove(entity);
    }
  }
}
