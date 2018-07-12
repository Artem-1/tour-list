using System;
using System.Collections.Generic;
using System.Text;
using TourList.Data.Interfaces;
using TourList.Service.Interfaces;
using TourList.Model;
using TourList.Dto;

namespace TourList.Service.Implementation
{
  public class ExcursionService : BaseService<ExcursionDto, Excursion>, IExcursionService
  {
    public ExcursionService(IRepositoryInject repository)
      : base(repository.Excursions)
    {
    }
  }
}
