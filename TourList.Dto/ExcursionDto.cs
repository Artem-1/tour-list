using System;
using System.Collections.Generic;

namespace TourList.Dto
{
  public class ExcursionDto
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<TourDto> Tours { get; set; }
    public ICollection<ExcursionSightDto> ExcursionSights { get; set; }
  }
}
