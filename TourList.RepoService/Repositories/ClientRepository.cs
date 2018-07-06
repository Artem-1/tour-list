using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TourList.Dto;
using TourList.Model;
using TourList.RepoService.Interfaces;

namespace TourList.RepoService.Repositories
{
  public class ClientRepository : BaseRepository<Client, ClientDto>, IClientRepository
  {
    public ClientRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Clients)
    {
    }

    public IEnumerable<TourDto> GetTours(Guid idClient)
    {
      var client = _dbSet.Include(tc => tc.TourClients)
        .ThenInclude(tc => tc.Tour)
        .FirstOrDefault(c => c.Id == idClient);

      var tours = client.TourClients.Select(tc => tc.Tour).ToList();

      return tours.Select(t => new TourDto()
      {
        Id = t.Id,
        Date = t.Date
      });
    }

    protected override ClientDto GetDto(Client c)
    {
      return new ClientDto()
      {
        Id = c.Id,
        Name = c.Name,
        //Tours = _tourRepo.GetClients(c.Id)
      };
    }

    protected override Client GetModel(ClientDto c)
    {
      return new Client()
      {
        Id = c.Id,
        Name = c.Name
      };
    }
  }
}
