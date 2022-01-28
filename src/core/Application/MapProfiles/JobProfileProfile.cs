using AutoMapper;
using Domain.Models;

namespace Application.MapProfiles
{
    public class JobProfileProfile : Profile
    {
        public JobProfileProfile()
        {
            CreateMap<JobProfile, DTOs.Profile>();
        }
    }
}