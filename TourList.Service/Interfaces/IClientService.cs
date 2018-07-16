using System;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IClientService : IService<ClientDto>
  {
    Guid Set(string name);
  }
}
