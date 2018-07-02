using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Client
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<TourExcursion> TourExcursions { get; set; }

    public Client()
    {
      TourExcursions = new List<TourExcursion>();
    }
  }
}
