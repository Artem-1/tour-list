using System;
using System.Collections.Generic;
using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface IClientService
  {
    IEnumerable<ClientDto> GetAll();
    IEnumerable<string> GetNames();
    ClientDto Get(Guid clientId);
    Guid SetClient(string name);
  }
}
