using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Tour
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    
    public ICollection<TourClient> TourClients { get; set; }
    public ICollection<TourExcursion> TourExcursions { get; set; }

    public Tour()
    {
      TourClients = new List<TourClient>();
      TourExcursions = new List<TourExcursion>();
    }
  }
}
