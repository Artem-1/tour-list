using System;
using System.Collections.Generic;

namespace TourList.Dto
{
  public class ExcursionDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<ExcursionSightDto> ExcursionSights { get; set; }
  }
}
