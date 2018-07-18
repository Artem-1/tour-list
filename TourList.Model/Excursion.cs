using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Excursion
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<Tour> Tours { get; set; }
    public IEnumerable<ExcursionSight> ExcursionSights { get; set; }
    
    public Excursion()
    {
      Tours = new List<Tour>();
      ExcursionSights = new List<ExcursionSight>();
    }
  }
}
