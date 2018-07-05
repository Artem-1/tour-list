using System;

namespace TourList.Model
{
  public class TourClient
  {
    public Guid TourId { get; set; }
    public Tour Tour { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }
  }
}
