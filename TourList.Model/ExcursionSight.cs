using System;

namespace TourList.Model
{
  public class ExcursionSight
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid ExcursionId { get; set; }
    public Excursion Excursion { get; set; }
  }
}
