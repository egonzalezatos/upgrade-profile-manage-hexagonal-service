using Application.DTOs;
using Domain.Models;
using Profile = AutoMapper.Profile;

namespace Application.MapProfiles
{
    public class JobPositionProfile : Profile
    {
        public JobPositionProfile()
        {
            CreateMap<JobPosition, Position>();
        }
    }
}