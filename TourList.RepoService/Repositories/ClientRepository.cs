namespace TourList.RepoService.Repositories
{
  public class ClientRepository : BaseRepository<Model.Client>, Interfaces.IClientRepository
  {
    public ClientRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Clients)
    {
    }
  }
}
