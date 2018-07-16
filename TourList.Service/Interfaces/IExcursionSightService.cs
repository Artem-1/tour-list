using System;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IExcursionSightService : IService<ExcursionSightDto>
  {
    Guid Create(string name, Guid idExcursion);
  }
}
