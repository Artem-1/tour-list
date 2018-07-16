using System;
using System.Collections.Generic;
using TourList.Data.Interfaces;
using FastMapper.NetCore;

namespace TourList.Service.Implementation
{
  public abstract class BaseService<TDto, TEntity> : Interfaces.IService<TDto>
  {
    private readonly IRepository<TEntity> _repository;

    public BaseService(IRepository<TEntity> repository)
    {
      TypeAdapterConfig<TEntity, TDto>.NewConfig().MaxDepth(3);
      _repository = repository;
    }

    public IEnumerable<TDto> GetAll()
    {
      TypeAdapterConfig<IEnumerable<TEntity>, IEnumerable<TDto>>.NewConfig().MaxDepth(3);
      return TypeAdapter.Adapt<IEnumerable<TEntity>, IEnumerable<TDto>>(_repository.GetAll());
    }

    public TDto Get(Guid id)
    {
      var entity = _repository.GetEntity(id);
      return TypeAdapter.Adapt<TEntity, TDto>(entity);
    }
  }
}
