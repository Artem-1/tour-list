using TourList.Data.Interfaces;
using TourList.Model;

namespace TourList.Data.Repositories
{
  public class SnapshotSightRepository : BaseRepository<SnapshotSight>, ISnapshotSightRepository
  {
    public SnapshotSightRepository(TourListContext context)
      : base(context)
    {
    }
  }
}
