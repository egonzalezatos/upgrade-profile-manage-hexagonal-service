using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.ManagementModels;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.Implementations
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(EntityContext entityContext) : base(entityContext)
        {
        }

        public async Task<List<UserProfile>> FindByUserId(int userId)
        {
            return await dbSet.Where(entity => entity.UserId == userId).ToListAsync();
        }
        
        public async Task<List<UserProfile>> FindByUserIdAndPositionId(int userId, int positionId)
        {
            return await dbSet.Where(entity => entity.UserId == userId && entity.JobProfile.JobPosition.Id == positionId).ToListAsync();
        }
        
        public async Task<List<UserProfile>> FindByUserIds(List<int> userIds)
        {
            var queryable = dbSet.Where(entity => userIds.Contains(entity.UserId))
                .Include(entity => entity.JobProfile)
                .Include(entity => entity.JobProfile.Level)
                .Include(entity => entity.JobProfile.Level.Status)
                .Include(entity => entity.JobProfile.Technology)
                .Include(entity => entity.JobProfile.Technology.Status)
                .Include(entity => entity.JobProfile.JobPosition)
                .Include(entity => entity.JobProfile.JobPosition.Status);
                
            Console.Out.WriteLine(queryable.ToQueryString());
            return await queryable.ToListAsync();
        }
    }
}