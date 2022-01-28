using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mappers;
using Domain.Models;
using Domain.Models.ManagementModels;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IPositionMapper _positionMapper;

        public PositionService(IPositionRepository positionRepository, IUserProfileRepository userProfileRepository, IPositionMapper positionMapper)
        {
            _positionRepository = positionRepository;
            _userProfileRepository = userProfileRepository;
            _positionMapper = positionMapper;
        }

        public async Task<List<DTOs.Position>> GetAll()
        {
            List<JobPosition> positions = await _positionRepository.FindAll();
            return _positionMapper.ToDto<DTOs.Position>(positions);
        }

        public async Task<List<DTOs.Position>> GetByUserId(int userId)
        {
            List<UserProfile> profiles = await _userProfileRepository.FindByUserId(userId);
            List<JobPosition> positions = profiles.Select(profile => profile.JobProfile.JobPosition).ToList();
            return _positionMapper.ToDto<DTOs.Position>(positions);
        }
        
    }
}