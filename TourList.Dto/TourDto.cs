using System;
using System.Collections.Generic;

namespace TourList.Dto
{
  public class TourDto
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public ClientDto Client { get; set; }
    public ExcursionDto Excursion { get; set; }
    public IEnumerable<SnapshotSightDto> SnapshotSights { get; set; }
  }
}
