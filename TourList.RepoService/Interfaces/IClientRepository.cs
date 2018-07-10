using System;
using System.Collections.Generic;
using TourList.Model;

namespace TourList.Data.Interfaces
{
  public interface IClientRepository : IRepository<Client>
  {
    ICollection<Tour> GetTours(Guid idClient);
  }
}
