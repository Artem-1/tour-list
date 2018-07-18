using TourList.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TourList.Data.Repositories
{
  public class ExcursionRepository : BaseRepository<Excursion>, Interfaces.IExcursionRepository
  {
    private DbSet<Excursion> _dbExcursions;

    public ExcursionRepository(TourListContext dbContext)
      : base(dbContext)
    {
      _dbExcursions = dbContext.Excursions;
    }

    public override IEnumerable<Excursion> GetAll()
    {
      return _dbExcursions.Include(e => e.ExcursionSights);
    }

    public override Excursion GetEntity(Guid id)
    {
      return _dbExcursions.Include(e => e.ExcursionSights).FirstOrDefault(e => e.Id == id);
    }

    public Excursion FindByName(string name)
    {
      return _dbExcursions.SingleOrDefault(e => e.Name == name);
    }
  }
}
