using TourList.Model;
using TourList.Dto;

namespace TourList.RepoService.Repositories
{
  public class ExcursionSightRepository : BaseRepository<ExcursionSight, ExcursionSightDto>, Interfaces.IExcursionSightRepository
  {
    public ExcursionSightRepository(TourListContext dbContext)
      : base(dbContext, dbContext.ExcursionSights)
    {
    }

    protected override ExcursionSightDto GetDto(ExcursionSight entity)
    {
      return new ExcursionSightDto()
      {
      };
    }

    protected override ExcursionSight GetModel(ExcursionSightDto entity)
    {
      throw new System.NotImplementedException();
    }
  }
}
