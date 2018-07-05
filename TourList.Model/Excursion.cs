using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Excursion
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<TourExcursion> TourExcursions { get; set; }

    public Excursion()
    {
      TourExcursions = new List<TourExcursion>();
    }
  }
}
