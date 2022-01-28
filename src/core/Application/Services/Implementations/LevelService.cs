using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mappers;
using Domain.Models;
using Domain.Models.ManagementModels;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class LevelService : ILevelService
    {
        private readonly ILevelRepository _levelRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ILevelMapper _levelMapper;
        public LevelService(ILevelRepository levelRepository, ILevelMapper levelMapper, IUserProfileRepository userProfileRepository)
        {
            _levelRepository = levelRepository;
            _levelMapper = levelMapper;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<List<DTOs.Level>> GetAll()
        {
            List<Level> levels = await _levelRepository.FindAll();
            return _levelMapper.ToDto<DTOs.Level>(levels);
        }

        public async Task<List<DTOs.Level>> GetByUserIdPositionId(int userId, int positionId)
        {
            List<UserProfile> profiles = await _userProfileRepository.FindByUserIdAndPositionId(userId, positionId);
            List<Level> levels = profiles.Select(profile => profile.JobProfile.Level).ToList();
            return _levelMapper.ToDto<DTOs.Level>(levels);
        }
    }
}