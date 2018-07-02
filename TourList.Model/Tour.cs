using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Tour
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }

    public ICollection<TourExcursion> TourEx { get; set; }

    public Tour()
    {
      TourEx = new List<TourExcursion>();
    }
  }
}
