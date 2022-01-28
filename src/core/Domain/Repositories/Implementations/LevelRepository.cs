using Domain.Repositories;
using Domain.Models;

namespace Domain.Repositories.Implementations
{
    public class LevelRepository : Repository<Level>, ILevelRepository
    {
        public LevelRepository(EntityContext entityContext) : base(entityContext)
        {
        }
    }
}