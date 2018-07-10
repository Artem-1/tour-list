using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TourList.Model;
using TourList.Data.Interfaces;

namespace TourList.Data.Repositories
{
  public class ClientRepository : BaseRepository<Client>, IClientRepository
  {
    public ClientRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Clients)
    {
    }

    public ICollection<Tour> GetTours(Guid idClient)
    {
      return null;
    }
  }
}
