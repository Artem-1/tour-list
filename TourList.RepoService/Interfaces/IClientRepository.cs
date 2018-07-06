using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.RepoService.Interfaces
{
  public interface IClientRepository : IRepository<ClientDto>
  {
    IEnumerable<TourDto> GetTours(Guid idClient);
  }
}
