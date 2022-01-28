using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public interface IProfileService
    {
        public Task<List<DTOs.Profile>> GetAll();
        public Task<List<DTOs.Profile>> GetByUserId(int userId);
        public Task<List<DTOs.Profile>> GetByUsersIds(List<int> userIds);
        public Task<DTOs.Profile> GetByFlattenPlan(int positionId, int levelId, int technologyId);
    }
}