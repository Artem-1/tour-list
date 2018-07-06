using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TourList.RepoService
{
  public abstract class BaseRepository<TEntity, TDto> : Interfaces.IRepository<TDto>
    where TEntity: class
  {
    private bool disposed = false;

    protected TourListContext _dbContext;
    protected DbSet<TEntity> _dbSet;
    
    public BaseRepository(TourListContext context, DbSet<TEntity> dbSet)
    {
      _dbContext = context;
      _dbSet = dbSet;
    }

    public IEnumerable<TDto> GetAll()
    {
      return _dbSet.Select(c => GetDto(c));
    }

    public TDto GetEntity(Guid id)
    {
      return GetDto(_dbSet.Find(id));
    }

    public void Create(TDto item)
    {
      _dbSet.Add(GetModel(item));
    }

    public void Update(TDto item)
    {
      _dbContext.Entry(GetModel(item)).State = EntityState.Modified;
    }

    public void Delete(Guid id)
    {
      TEntity entity = _dbSet.Find(id);
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

    protected abstract TDto GetDto(TEntity entity);
    protected abstract TEntity GetModel(TDto entity);
  }
}
