using TourList.Model;
using TourList.Dto;

namespace TourList.RepoService.Repositories
{
  public class ExcursionRepository : BaseRepository<Excursion, ExcursionDto>, Interfaces.IExcursionRepository
  {
    public ExcursionRepository(TourListContext dbContext)
      : base(dbContext, dbContext.Excursions)
    {
    }

    protected override ExcursionDto GetDto(Excursion entity)
    {
      return new ExcursionDto()
      {
      };
    }

    protected override Excursion GetModel(ExcursionDto entity)
    {
      return new Excursion();
    }
  }
}
