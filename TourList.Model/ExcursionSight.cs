using System;

namespace TourList.Model
{
  public class ExcursionSight
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid TourExcursionId { get; set; }
    public TourExcursion TourExcursion { get; set; }
  }
}
