using Domain.Models;

namespace Domain.Repositories.Implementations
{
    public class TechnologyRepository : Repository<Technology>, ITechnologyRepository
    {
        public TechnologyRepository(EntityContext entityContext) : base(entityContext)
        {
        }
    }
}