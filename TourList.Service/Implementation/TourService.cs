﻿using FastMapper.NetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class TourService : ITourService
  {
    private readonly IRepositoryInject _uow;
    private readonly IExcursionService _excursionService;
    private readonly IClientService _clientSerivce;

    public TourService(IRepositoryInject repository, IExcursionService excursionService, IClientService clientSerivce)
    {
      _uow = repository;
      _excursionService = excursionService;
      _clientSerivce = clientSerivce;
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
      SetTour(dto);

      var newTour = TypeAdapter.Adapt<Tour>(dto);
      newTour.Id = Guid.NewGuid();

      if (_uow.Excursions.FindByName(newTour?.Excursion.Name) != null)
      {
        AddSnapshotSights(newTour);
        newTour.Excursion = null;
      }

      if (_uow.Clients.FindByName(newTour?.Client.Name) != null)
        newTour.Client = null;

      _uow.Tours.Create(newTour);
      _uow.Save();
    }

    public void Edit(TourDto dto)
    {
      if (dto == null || dto.Client == null || dto.Excursion == null)
        throw new Exception("no correct Tour");

      var tour = _uow.Tours.GetEntity(dto.Id);

      if (tour == null)
        throw new Exception("not found tour");

      SetTour(dto);
      AddSnapshotSights(tour);
      _uow.Tours.Update(TypeAdapter.Adapt<Tour>(dto));
      _uow.Save();
    }

    private void SetTour(TourDto dto)
    {
      if (dto.Excursion != null)
      {
        var ex = _excursionService.SetExcursion(dto.Excursion.Name, dto.Excursion.ExcursionSights);
        dto.Excursion = _excursionService.Get(ex);
      }

      if (dto.Client != null && dto.Client.Id == Guid.Empty)
      {
        var cl = _clientSerivce.SetClient(dto.Client.Name);
        dto.Client = _clientSerivce.Get(cl);
      }
    }

    private void AddSnapshotSights(Tour tour)
    {
      var excursionSights = tour.Excursion.ExcursionSights.ToList();

      foreach (var item in excursionSights)
      {
        var snapshot = tour.SnapshotSights.FirstOrDefault(ss => ss.Name == item.Name);

        if (snapshot != null)
          continue;

        snapshot = new SnapshotSight
        {
          Id = Guid.NewGuid(),
          Name = item.Name,
          TourId = tour.Id
        };

        _uow.SnapshotSights.Create(snapshot);
      }
    }
  }
}
