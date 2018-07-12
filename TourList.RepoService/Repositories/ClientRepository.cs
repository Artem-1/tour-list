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
  }
}
