using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories
{
    public interface IJobProfileRepository : IRepository<JobProfile>
    {
        public Task<JobProfile> FindByPositionIdAndLevelIdAndTechnologyId(int positionId, int levelId, int technologyId);
    }
}