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
    private IRepositoryInject _db;

    public ExcursionService(IRepositoryInject repository)
      : base(repository.Excursions)
    {
      _db = repository;
    }

    public override void Update(ExcursionDto dto)
    {
      var en = _repository.GetEntity(dto.Id);
      var sights = TypeAdapter.Adapt<ICollection<ExcursionSightDto>, ICollection<ExcursionSight>>(dto.ExcursionSights);

      foreach (var item in sights)
      {
        if (_db.ExcursionSights.GetEntity(item.Id) == null)
        {
          item.Id = Guid.NewGuid();
          item.ExcursionId = en.Id;
          _db.ExcursionSights.Create(item);
        }
      }

      foreach (var item in en.ExcursionSights)
      {
        if (sights.FirstOrDefault(s => s.Id == item.Id) == null)
          _db.ExcursionSights.Delete(item.Id);
      }

      _repository.Update(en);
    }

  }
}
