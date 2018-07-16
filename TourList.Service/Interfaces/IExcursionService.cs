using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IExcursionService : IService<ExcursionDto>
  {
    Guid Set(string name, IEnumerable<ExcursionSightDto> sights);
  }
}
