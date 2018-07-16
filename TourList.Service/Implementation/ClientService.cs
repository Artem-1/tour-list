using FastMapper.NetCore;
using System;
using System.Collections.Generic;
using TourList.Data.Interfaces;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Service.Implementation
{
  public class ClientService : IClientService
  {
    private readonly IClientRepository _clients;

    public ClientService(IRepositoryInject repository)
    {
      _clients = repository.Clients;
    }

    public IEnumerable<ClientDto> GetAll()
    {
      return TypeAdapter.Adapt<IEnumerable<Client>, IEnumerable<ClientDto>>(_clients.GetAll());
    }

    public ClientDto Get(Guid id)
    {
      var entity = _clients.GetEntity(id);
      return TypeAdapter.Adapt<Client, ClientDto>(entity);
    }

    public Guid Set(string name)
    {
      var client = _clients.FindByName(name);

      if (client != null)
        return client.Id;

      var newClient = new Client() { Id = Guid.NewGuid(), Name = name };
      _clients.Create(newClient);

      return newClient.Id;
    }
  }
}
