using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mappers;
using Domain.Models;
using Domain.Models.ManagementModels;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly ITechnologyMapper _technologyMapper;

        public TechnologyService(ITechnologyRepository technologyRepository, ITechnologyMapper technologyMapper, IUserProfileRepository userProfileRepository)
        {
            _technologyRepository = technologyRepository;
            _technologyMapper = technologyMapper;
            _userProfileRepository = userProfileRepository;
        }
        
        public async Task<List<DTOs.Technology>> GetAll()
        {
            List<Technology> levels = await _technologyRepository.FindAll();
            return _technologyMapper.ToDto<DTOs.Technology>(levels);
        }

        public async Task<List<DTOs.Technology>> GetByUserIdPositionId(int userId, int positionId)
        {
            List<UserProfile> profiles = await _userProfileRepository.FindByUserIdAndPositionId(userId, positionId);
            List<Technology> technologies = profiles.Select(profile => profile.JobProfile.Technology).ToList();
            return _technologyMapper.ToDto<DTOs.Technology>(technologies);
        }
    }
}