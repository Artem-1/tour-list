using System;
using System.Collections.Generic;
using System.Text;

namespace TourList.Model
{
  public class SnapshotSight
  {
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Guid TourId { get; set; }
    public Tour Tour { get; set; }
  }
}
