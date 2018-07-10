using Microsoft.AspNetCore.Mvc;
using System;
using TourList.Dto;
using TourList.Model;
using TourList.Service.Interfaces;

namespace TourList.Controllers
{
  [Produces("application/json")]
  [Route("api/Tour")]
  public class TourController : BaseTourListController<ITourService, TourDto>
  {
    public TourController(ITourService serivce)
      : base(serivce)
    {
    }
  }
}