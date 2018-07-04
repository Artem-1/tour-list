﻿using Microsoft.AspNetCore.Mvc;
using TourList.Model;
using TourList.RepoService.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/User")]
  public class UserController : BaseTourListController<IUserRepository, User>
  {
    public UserController(IUserRepository dbUser)
      :base(dbUser)
    {
    }
  }
}