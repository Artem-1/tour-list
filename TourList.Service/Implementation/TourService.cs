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
  public class TourService : BaseService<TourDto, Tour>, ITourService
  {
    private IRepositoryInject _db;

    public TourService(IRepositoryInject repository)
      : base(repository.Tours)
    {
      _db = repository;
    }

    public override void Create(TourDto dto)
    {
      var tour = Apply(dto);
      _repository.Create(tour);
    }

    public override void Update(TourDto dto)
    {
      var tour = Apply(dto);
      _repository.Update(tour);
    }

    private Tour Apply(TourDto dto)
    {
      var entity = TypeAdapter.Adapt<TourDto, Tour>(dto);

      if (_db.Clients.GetEntity(entity.Client.Id) == null)
      {
        entity.Client.Id = Guid.NewGuid();
        _db.Clients.Create(entity.Client);
      }

      if (_db.Excursions.GetEntity(entity.Excursion.Id) == null)
      {
        entity.Excursion.Id = Guid.NewGuid();
        _db.Excursions.Create(entity.Excursion);

        foreach (var sight in entity.Excursion.ExcursionSights)
        {
          sight.Id = Guid.NewGuid();
          _db.ExcursionSights.Create(sight);
        }
      }
      else
      {
        var en = _db.Excursions.GetEntity(entity.Excursion.Id);
        var sights = entity.Excursion.ExcursionSights;

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
      }
      return entity;
    }
  }
}
