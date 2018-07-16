using TourList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TourList.Data.Repositories
{
  public class ExcursionRepository : BaseRepository<Excursion>, Interfaces.IExcursionRepository
  {
    public ExcursionRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Excursions)
    {
    }

    public override IEnumerable<Excursion> GetAll()
    {
      return _dbSet.Include(e => e.ExcursionSights);
    }

    public override Excursion GetEntity(Guid id)
    {
      return _dbSet.Include(e => e.ExcursionSights).FirstOrDefault(e => e.Id == id);
    }

    public Excursion FindByName(string name)
    {
      return _dbSet.SingleOrDefault(e => e.Name == name);
    }
  }
}
