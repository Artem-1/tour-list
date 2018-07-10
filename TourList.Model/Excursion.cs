using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Excursion
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Tour> Tours { get; set; }
    public ICollection<ExcursionSight> ExcursionSights { get; set; }
    
    public Excursion()
    {
      Tours = new List<Tour>();
      ExcursionSights = new List<ExcursionSight>();
    }
  }
}
