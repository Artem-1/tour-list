using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.RepoService.Interfaces
{
  public interface IClientRepository : IRepository<ClientDto>
  {
    ICollection<TourDto> GetTours(Guid id);
  }
}
