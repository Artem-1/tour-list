using System;
using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class TourService : BaseService<TourDto, Tour>, ITourService
  {
    private ITourRepository _tours;
    private IClientRepository _clients;
    private IExcursionRepository _excursions;
    private IExcursionSightRepository _excursionSights;

    public TourService(IRepositoryInject repository)
      : base(repository.Tours)
    {
      _tours = repository.Tours;
      _clients = repository.Clients;
      _excursions = repository.Excursions;
      _excursionSights = repository.ExcursionSights;
    }

    public void Create(TourDto dto)
    {
      _tours.Create(new Tour()
      {
        Date = dto.Date,
        ClientId = dto.Client.Id,
        ExcursionId = dto.Excursion.Id
      });
    }

    public void Edit(TourDto dto)
    {
      var tour = _tours.GetEntity(dto.Id);

      if (tour == null || tour.Client == null || tour.Excursion == null)
        throw new InvalidOperationException();

      tour.ClientId = dto.Client.Id;
      tour.ExcursionId = dto.Excursion.Id;

      _tours.Update(tour);
    }
  }
}
