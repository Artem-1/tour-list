using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IExcursionService
  {
    IEnumerable<ExcursionDto> GetAll();
    ExcursionDto Get(Guid excursionId);
    Guid SetExcursion(string name, IEnumerable<ExcursionSightDto> sights);
    void SetSights(string name, IEnumerable<ExcursionSightDto> sights);
  }
}
