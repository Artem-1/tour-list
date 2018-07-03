using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Client
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<Tour> Tours { get; set; }

    public Client()
    {
      Tours = new List<Tour>();
    }
  }
}
