using System;
using System.Collections.Generic;

namespace TourList.Service.Interfaces
{
  public interface IService<TDto>
  {
    IEnumerable<TDto> GetAll();
    TDto Get(Guid id);
    IEnumerable<TDto> Find(Func<TDto, Boolean> predicate);
    void Create(TDto dto);
    void Update(TDto dto);
    void Delete(Guid id);
  }
}
