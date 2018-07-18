using FastMapper.NetCore;
using System;
using System.Collections.Generic;
using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class TourService : ITourService
  {
    private readonly IRepositoryInject _uow;

    public TourService(IRepositoryInject repository)
    {
      _uow = repository;
    }

    public IEnumerable<TourDto> GetAll()
    {
      var t = _uow.Tours.GetAll();
      return TypeAdapter.Adapt<IEnumerable<Tour>, IEnumerable<TourDto>>(t);
    }

    public TourDto Get(Guid excursionId)
    {
      var entity = _uow.Tours.GetEntity(excursionId);
      return TypeAdapter.Adapt<TourDto>(entity);
    }

    public void Create(TourDto dto)
    {
      _uow.Tours.Create(TypeAdapter.Adapt<Tour>(dto));
    }

    public void Edit(TourDto dto)
    {
      if (dto == null || dto.Client == null || dto.Excursion == null)
        throw new Exception("no correct Tour");

      var tour = _uow.Tours.GetEntity(dto.Id);

      if (tour == null)
        throw new Exception("not find tour");

      _uow.Tours.Update(TypeAdapter.Adapt<Tour>(dto));
    }
  }
}
