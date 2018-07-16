using TourList.Model;

namespace TourList.Data.Interfaces
{
  public interface IClientRepository : IRepository<Client>
  {
    Client FindByName(string name);
  }
}
