using System;
using System.Collections.Generic;

namespace TourList.RepoService.Interfaces
{
  public interface IRepository<TDto> : IDisposable
  {
    IEnumerable<TDto> GetAll();
    TDto GetEntity(Guid id);
    void Create(TDto item);
    void Update(TDto item);
    void Delete(Guid id);
    void Save();
  }
}
