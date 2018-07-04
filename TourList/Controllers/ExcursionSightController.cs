﻿using Microsoft.AspNetCore.Mvc;
using TourList.Model;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/ExcursionSight")]
  public class ExcursionSightController : BaseTourListController<IExcursionSightRepository, ExcursionSight>
  {
    public ExcursionSightController(IExcursionSightRepository dbExcursionSight)
      :base(dbExcursionSight)
    {
    }
  }
}