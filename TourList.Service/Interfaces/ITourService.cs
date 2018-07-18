using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface ITourService
  {
    IEnumerable<TourDto> GetAll();
    TourDto Get(Guid tourId);
    void Create(TourDto dto);
    void Edit(TourDto dto);
  }
}
