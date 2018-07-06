using System;
using System.Collections.Generic;

namespace TourList.Dto
{
  public class TourDto
  {
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public ICollection<ClientDto> Clients { get; set; }
    public ICollection<ExcursionSightDto> ExcursionSights { get; set; }
    public ICollection<ExcursionDto> Excursions { get; set; }
  }
}
