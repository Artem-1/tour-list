using System.Linq;
using TourList.Data.Interfaces;
using TourList.Model;

namespace TourList.Data.Repositories
{
  public class ClientRepository : BaseRepository<Client>, IClientRepository
  {
    public ClientRepository(TourListContext dbContext)
      : base(dbContext)
    {
    }

    public Client FindByName(string name)
    {
      return DbContext.Set<Client>().SingleOrDefault(c => c.Name == name);
    }
  }
}
