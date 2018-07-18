using System;
using System.Collections.Generic;

namespace TourList.Model
{
  public class Tour
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }

    public Guid ExcursionId { get; set; }
    public Excursion Excursion { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }

    public IEnumerable<SnapshotSight> SnapshotSights { get; set; }

    public Tour()
    {
      SnapshotSights = new List<SnapshotSight>();
    }
  }
}
