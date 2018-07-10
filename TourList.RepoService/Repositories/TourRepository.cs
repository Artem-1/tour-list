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
    public TourRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Tours)
    {
    }

    public override IEnumerable<Tour> GetAll()
    {
      return _dbSet.Include(t => t.Client).Include(t => t.Excursion);
    }
  }
}
