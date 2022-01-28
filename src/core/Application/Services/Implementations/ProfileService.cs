using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mappers;
using Domain.Models;
using Domain.Models.ManagementModels;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IJobProfileRepository _profileRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IProfileMapper _profileMapper;

        public ProfileService(IJobProfileRepository profileRepository, IUserProfileRepository userProfileRepository, IProfileMapper profileMapper)
        {
            _profileRepository = profileRepository;
            _userProfileRepository = userProfileRepository;
            _profileMapper = profileMapper;
        }

        public async Task<List<DTOs.Profile>> GetAll()
        {
            List<JobProfile> profiles = await _profileRepository.FindAll();
            return _profileMapper.ToDto<DTOs.Profile>(profiles);
        }
        
        public async Task<List<DTOs.Profile>> GetByUserId(int userId)
        {
            List<UserProfile> userProfiles = await _userProfileRepository.FindByUserId(userId);
            IEnumerable<JobProfile> profiles = userProfiles.Select(profile => profile.JobProfile);
            return _profileMapper.ToDto<DTOs.Profile>(profiles.ToList());
        }
        
        public async Task<List<DTOs.Profile>> GetByUsersIds(List<int> userIds)
        {
            List<UserProfile> userProfiles = await _userProfileRepository.FindByUserIds(userIds);
            IEnumerable<JobProfile> profiles = userProfiles.Select(profile => profile.JobProfile);
            return _profileMapper.ToDto<DTOs.Profile>(profiles.ToList());
        }

        public async Task<DTOs.Profile> GetByFlattenPlan(int positionId, int levelId, int technologyId)
        {
            JobProfile profile =
                await _profileRepository.FindByPositionIdAndLevelIdAndTechnologyId(positionId, levelId, technologyId);
            return _profileMapper.ToDto<DTOs.Profile>(profile);
        }
    }
}