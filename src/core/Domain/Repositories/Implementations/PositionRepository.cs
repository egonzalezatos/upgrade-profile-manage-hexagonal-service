using Domain.Repositories; 
using Domain.Models;

namespace Domain.Repositories.Implementations
{
    public class PositionRepository : Repository<JobPosition>, IPositionRepository
    {
        public PositionRepository(EntityContext entityContext) : base(entityContext)
        {
        }
    }
}