using AutoMapper;
using Domain.Models;

namespace Application.MapProfiles
{
    public class StatusProfile : Profile
    {
        public StatusProfile()
        {
            CreateMap<Status, DTOs.Status>();
        }
    }
}