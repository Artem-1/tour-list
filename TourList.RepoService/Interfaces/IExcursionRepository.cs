using TourList.Model;

namespace TourList.Data.Interfaces
{
  public interface IExcursionRepository : IRepository<Excursion>
  {
    Excursion FindByName(string name);
  }
}
