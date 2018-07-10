using System;
using System.Collections.Generic;
using System.Text;
using TourList.Data.Interfaces;
using TourList.Service.Interfaces;
using TourList.Model;
using TourList.Dto;

namespace TourList.Service.Implementation
{
  public class TourService : BaseService<TourDto, Tour>, ITourService
  {
    public TourService(ITourRepository repository)
      : base(repository)
    {
    }

  }
}
