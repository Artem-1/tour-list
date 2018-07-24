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
    private readonly IRepositoryInject _uow;

    public ClientService(IRepositoryInject repository)
    {
      _uow = repository;
    }

    public IEnumerable<ClientDto> GetAll()
    {
      return TypeAdapter.Adapt<IEnumerable<Client>, IEnumerable<ClientDto>>(_uow.Clients.GetAll());
    }

    public ClientDto Get(Guid clientId)
    {
      var entity = _uow.Clients.GetEntity(clientId);
      return TypeAdapter.Adapt<ClientDto>(entity);
    }

    public Guid SetClient(string name)
    {
      var client = _uow.Clients.FindByName(name);

      if (client != null)
        return client.Id;

      return Create(name);
    }

    private Guid Create(string name)
    {
      var newClient = new Client() { Id = Guid.NewGuid(), Name = name };
      _uow.Clients.Create(newClient);
      _uow.Save();

      return newClient.Id;
    }
  }
}
