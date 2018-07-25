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
  public class ExcursionService : IExcursionService
  {
    private readonly IRepositoryInject _uow;

    public ExcursionService(IRepositoryInject repository)
    {
      _uow = repository;
    }

    public IEnumerable<ExcursionDto> GetAll()
    {
      return TypeAdapter.Adapt<IEnumerable<Excursion>, IEnumerable<ExcursionDto>>(_uow.Excursions.GetAll());
    }

    public ExcursionDto Get(Guid excursionId)
    {
      var entity = _uow.Excursions.GetEntity(excursionId);
      return TypeAdapter.Adapt<ExcursionDto>(entity);
    }

    public Guid SetExcursion(string name, IEnumerable<ExcursionSightDto> sights)
    {
      var excursion = _uow.Excursions.FindByName(name);

      if (excursion == null)
      {
        //if (sights.Count() < 1)
        //  throw new Exception();

        return Create(name, sights);
      }

      SetSights(name, sights);

      return excursion.Id;
    }

    private Guid Create(string name, IEnumerable<ExcursionSightDto> sights)
    {
      var newSights = new List<ExcursionSight>(); // TypeAdapter.Adapt<IEnumerable<ExcursionSight>>(sights);
      var newExcursion = new Excursion() { Id = Guid.NewGuid(), Name = name, ExcursionSights = newSights.ToList() };
      _uow.Excursions.Create(newExcursion);
      _uow.Save();

      return newExcursion.Id;
    }

    public void SetSights(string name, IEnumerable<ExcursionSightDto> sights)
    {
      var excursion = _uow.Excursions.FindByName(name);

      var oldSights = excursion.ExcursionSights;
      var newSights = TypeAdapter.Adapt<IEnumerable<ExcursionSight>>(sights);

      foreach (var item in oldSights)
          _uow.ExcursionSights.Delete(item.Id);

      foreach (var item in newSights)
      {
          item.Id = Guid.NewGuid();
          item.ExcursionId = excursion.Id;
          _uow.ExcursionSights.Create(item);
      }

      _uow.Save();
    }

    public class GenericCompare<T> : IEqualityComparer<T> where T : class
    {
      private Func<T, object> _expr { get; set; }
      public GenericCompare(Func<T, object> expr)
      {
        this._expr = expr;
      }
      public bool Equals(T x, T y)
      {
        var first = _expr.Invoke(x);
        var sec = _expr.Invoke(y);
        if (first != null && first.Equals(sec))
          return true;
        else
          return false;
      }
      public int GetHashCode(T obj)
      {
        return obj.GetHashCode();
      }
    }
  }
}
