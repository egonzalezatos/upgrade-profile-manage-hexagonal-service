using AutoMapper;
using Domain.Models;

namespace Application.MapProfiles
{
    public class TechnologyProfile : Profile
    {
        public TechnologyProfile()
        {
            CreateMap<Technology, DTOs.Technology>();
        }
    }
}