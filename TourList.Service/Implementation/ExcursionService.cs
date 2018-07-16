using FastMapper.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class ExcursionService : BaseService<ExcursionDto, Excursion>, IExcursionService
  {
    private IExcursionRepository _excursions;
    private IExcursionSightRepository _excursionSights;

    public ExcursionService(IRepositoryInject repository)
      : base(repository.Excursions)
    {
      _excursions = repository.Excursions;
      _excursionSights = repository.ExcursionSights;
    }

    public Guid Set(string name, IEnumerable<ExcursionSightDto> sights)
    {
      var excursion = _excursions.FindByName(name);

      if (excursion == null)
      {
        if (sights.Count() < 1)
          throw new Exception();

        return Create(name, sights);
      }

      SetSights(name, sights);

      return excursion.Id;
    }

    private Guid Create(string name, IEnumerable<ExcursionSightDto> sights)
    {
      var newSights = TypeAdapter.Adapt<IEnumerable<ExcursionSightDto>, IEnumerable<ExcursionSight>>(sights);
      var newExcursion = new Excursion() { Id = Guid.NewGuid(), Name = name, ExcursionSights = newSights.ToList() };
      _excursions.Create(newExcursion);
      return newExcursion.Id;
    }

    private void SetSights(string name, IEnumerable<ExcursionSightDto> sights)
    {
      var excursion = _excursions.FindByName(name);

      var oldSights = excursion.ExcursionSights;
      var newSights = TypeAdapter.Adapt<IEnumerable<ExcursionSightDto>, IEnumerable<ExcursionSight>>(sights);

      foreach (var item in oldSights)
      {
        if (oldSights.SingleOrDefault(s => s.Id == item.Id) == null)
          _excursionSights.Delete(item.Id);
      }

      foreach (var item in newSights)
      {
        if (_excursionSights.GetEntity(item.Id) == null)
        {
          item.Id = Guid.NewGuid();
          item.ExcursionId = excursion.Id;
          _excursionSights.Create(item);
        }
      }
    }

  }
}
