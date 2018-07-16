using TourList.Dto;

namespace TourList.Service.Interfaces
{
  public interface ITourService : IService<TourDto>
  {
    void Create(TourDto dto);
    void Edit(TourDto dto);
  }
}
