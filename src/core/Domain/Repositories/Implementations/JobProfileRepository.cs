using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Implementations
{
    public class JobProfileRepository : Repository<JobProfile>, IJobProfileRepository
    {
        public JobProfileRepository(EntityContext entityContext) : base(entityContext)
        {
        }

        public async Task<JobProfile> FindByPositionIdAndLevelIdAndTechnologyId(int positionId, int levelId, int technologyId)
        {
            var query = dbSet.Where(entity => entity.JobPosition.Id == positionId)
                .Where(entity => entity.Level.Id == levelId)
                .Where(entity => entity.Technology.Id == technologyId);
            return await query.FirstAsync();
        }
    }
}