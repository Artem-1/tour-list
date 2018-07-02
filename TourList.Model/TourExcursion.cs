using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class TourExcursion
  {
    public Guid Id { get; set; }

    public Guid ExcursionId { get; set; }
    public Excursion Excursion { get; set; }

    public Guid TourId { get; set; }
    public Tour Tour { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }

    public ICollection<ExcursionSight> ExcursionSights { get; set; }

    public TourExcursion()
    {
      ExcursionSights = new List<ExcursionSight>();
    }
  }
}
