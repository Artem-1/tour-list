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

    public void AddSight(Guid idExcursion, Guid idSight)
    {

    }

    public ICollection<ExcursionSight> GetExcursionSights(Guid idExcursion)
    {
      return null;
    }
  }
}
