using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Client
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<TourClient> TourClients { get; set; }

    public Client()
    {
      TourClients = new List<TourClient>();
    }
  }
}
