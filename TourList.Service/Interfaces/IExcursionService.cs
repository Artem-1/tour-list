using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IExcursionService
  {
    IEnumerable<ExcursionDto> GetAll();
    IEnumerable<string> GetNames();
    ExcursionDto Get(Guid excursionId);
    Guid SetExcursion(string name, IEnumerable<ExcursionSightDto> sights);
    void SetSights(string name, IEnumerable<ExcursionSightDto> sights);
    IEnumerable<ExcursionSightDto> GetSights(string nameExcursion);
  }
}
