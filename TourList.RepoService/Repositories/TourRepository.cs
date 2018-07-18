using TourList.Model;
using TourList.Data.Interfaces;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TourList.Data.Repositories
{
  public class TourRepository : BaseRepository<Tour>, ITourRepository
  {
    private DbSet<Tour> _dbTours;

    public TourRepository(TourListContext dbContext)
      : base(dbContext)
    {
      _dbTours = DbContext.Tours;
    }

    public override IEnumerable<Tour> GetAll()
    {
      return _dbTours.Include(t => t.Client).Include(t => t.Excursion).ToList();
    }

    public override Tour GetEntity(Guid id)
    {
      return _dbTours.Include(t => t.Client).Include(t => t.Excursion).SingleOrDefault(t => t.Id == id);
    }
  }
}
