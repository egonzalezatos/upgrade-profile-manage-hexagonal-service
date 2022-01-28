using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models.ManagementModels;

namespace Domain.Repositories
{
    public interface IUserProfileRepository
    {
        public Task<List<UserProfile>> FindByUserId(int userId);
        public Task<List<UserProfile>> FindByUserIdAndPositionId(int userId, int positionId);
        
        public Task<List<UserProfile>> FindByUserIds(List<int> userIds);
    }
}