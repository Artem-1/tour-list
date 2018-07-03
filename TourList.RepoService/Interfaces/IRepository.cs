using System;
using System.Collections.Generic;

namespace TourList.RepoService.Interfaces
{
  public interface IRepository<T> : IDisposable 
    where T: class
  {
    IEnumerable<T> GetList();
    T GetEntity(Guid id);
    void Create(T item);
    void Update(T item);
    void Delete(Guid id);
    void Save();
  }
}
