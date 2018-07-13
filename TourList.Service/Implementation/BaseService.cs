using System;
using System.Collections.Generic;
using TourList.Data.Interfaces;
using FastMapper.NetCore;

namespace TourList.Service.Implementation
{
  public abstract class BaseService<TDto, TEntity> : Interfaces.IService<TDto>
  {
    protected readonly IRepository<TEntity> _repository;

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

    public virtual void Create(TDto dto)
    {
      var entity = TypeAdapter.Adapt<TDto, TEntity>(dto);
      _repository.Create(entity);
    }

    public virtual void Update(TDto dto)
    {
      var entity = TypeAdapter.Adapt<TDto, TEntity>(dto);
      _repository.Update(entity);
    }

    public void Delete(Guid id)
    {
      _repository.Delete(id);
    }

    public IEnumerable<TDto> Find(Func<TDto, bool> predicate)
    {
      var newPredicate = TypeAdapter.Adapt<Func<TDto, bool>, Func<TEntity, bool>>(predicate);
      var listEntity = _repository.Find(newPredicate);
      var listDto = TypeAdapter.Adapt<IEnumerable<TEntity>, IEnumerable<TDto>>(listEntity);
      return listDto;
    }
  }
}
