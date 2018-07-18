using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IExcursionSightService
  {
    IEnumerable<ExcursionSightDto> GetAll();
    ExcursionSightDto Get(Guid sightId);
    Guid Create(string name, Guid excursionId);
  }
}
