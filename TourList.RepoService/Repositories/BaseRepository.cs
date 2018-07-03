using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace TourList.RepoService
{
  public class BaseRepository<T> : Interfaces.IRepository<T>
    where T: class
  {
    private bool disposed = false;

    private TourListContext _dbContext;
    private DbSet<T> _dbSet;
    
    public BaseRepository(TourListContext context, DbSet<T> dbSet)
    {
      _dbContext = context;
      _dbSet = dbSet;
    }

    public IEnumerable<T> GetList()
    {
      return _dbSet;
    }

    public T GetEntity(Guid id)
    {
      return _dbSet.Find(id);
    }

    public void Create(T entity)
    {
      _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
      _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(Guid id)
    {
      T entity = _dbSet.Find(id);
      if (entity != null)
        _dbSet.Remove(entity);
    }

    public void Save()
    {
      _dbContext.SaveChanges();
    }

    public virtual void Dispose(bool disposing)
    {
      if (!disposed)
      {
        if (disposing)
        {
          _dbContext.Dispose();
        }
      }
      disposed = true;
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this);
    }
  }
}
