using TourList.Model;
using TourList.Dto;
using TourList.RepoService.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TourList.RepoService.Repositories
{
  public class TourRepository : BaseRepository<Tour, TourDto>, ITourRepository
  {
    public TourRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Tours)
    {
    }

    public IEnumerable<ClientDto> GetClients(Guid idTour)
    {
      var tour = _dbSet.Include(tc => tc.TourClients)
        .ThenInclude(tc => tc.Client)
        .FirstOrDefault(t => t.Id == idTour);

      var clients = tour.TourClients.Select(tc => tc.Client).ToList();

      return clients.Select(c => new ClientDto()
      {
        Id = c.Id,
        Name = c.Name
      });
    }

    public void AddClient(Guid idTour, Guid idClient)
    {
      _dbContext.TourClients.Add(new TourClient() { TourId = idTour, ClientId = idClient });
    }

    protected override TourDto GetDto(Tour entity)
    {
      return new TourDto()
      {
        Id = entity.Id,
        Date = entity.Date
      };
    }

    protected override Tour GetModel(TourDto entity)
    {
      return new Tour()
      {
        Id = entity.Id,
        Date = entity.Date
      };
    }
  }
}
