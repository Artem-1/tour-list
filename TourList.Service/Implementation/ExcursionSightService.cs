using FastMapper.NetCore;
using System;
using System.Collections.Generic;
using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class ExcursionSightService : IExcursionSightService
  {
    private readonly IExcursionSightRepository _excursionSights;
    private readonly ITourRepository _tours;

    public ExcursionSightService(IRepositoryInject repository)
    {
      _excursionSights = repository.ExcursionSights;
      _tours = repository.Tours;
    }

    public IEnumerable<ExcursionSightDto> GetAll()
    {
      return TypeAdapter.Adapt<IEnumerable<ExcursionSight>, IEnumerable<ExcursionSightDto>>(_excursionSights.GetAll());
    }

    public ExcursionSightDto Get(Guid id)
    {
      var entity = _excursionSights.GetEntity(id);
      return TypeAdapter.Adapt<ExcursionSight, ExcursionSightDto>(entity);
    }

    public Guid Create(string name, Guid idExcursion)
    {
      var newSight = new ExcursionSight()
      {
        Id = Guid.NewGuid(),
        Name = name,
        ExcursionId = idExcursion
      };

      _excursionSights.Create(newSight);
      
      return newSight.Id;
    }

    public void Delete(Guid id)
    {
      _excursionSights.Delete(id);
    }
  }
}
