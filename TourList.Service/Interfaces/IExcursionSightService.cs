using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IExcursionSightService
  {
    IEnumerable<ExcursionSightDto> GetAll();
    IEnumerable<string> GetNames();
    ExcursionSightDto Get(Guid sightId);
    Guid Create(string name, Guid excursionId);
  }
}
