using AutoMapper;
using Domain.Models;

namespace Application.MapProfiles
{
    public class LevelProfile : Profile
    {
        public LevelProfile()
        {
            CreateMap<Level, DTOs.Level>();
        }
    }
}