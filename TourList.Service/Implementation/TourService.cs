﻿using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class TourService : BaseService<TourDto, Tour>, ITourService
  {
    public TourService(IRepositoryInject repository)
      : base(repository.Tours)
    {
    }
  }
}
