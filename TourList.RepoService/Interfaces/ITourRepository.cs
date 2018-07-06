using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.RepoService.Interfaces
{
  public interface ITourRepository : IRepository<TourDto>
  {
    IEnumerable<ClientDto> GetClients(Guid idTour);
    void AddClient(Guid idTour, Guid idClient);
  }
}
