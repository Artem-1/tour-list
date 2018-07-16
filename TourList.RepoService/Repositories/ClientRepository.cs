using System.Linq;
using TourList.Data.Interfaces;
using TourList.Model;

namespace TourList.Data.Repositories
{
  public class ClientRepository : BaseRepository<Client>, IClientRepository
  {
    public ClientRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Clients)
    {
    }

    public Client FindByName(string name)
    {
      return _dbSet.SingleOrDefault(c => c.Name == name);
    }
  }
}
