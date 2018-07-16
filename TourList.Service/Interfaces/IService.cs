using System;
using System.Collections.Generic;

namespace TourList.Service.Interfaces
{
  public interface IService<TDto>
  {
    IEnumerable<TDto> GetAll();
    TDto Get(Guid id);
  }
}
