using AutoMapper;
using Domain.Models;

namespace Application.Mappers.Impl
{
    public class ProfileMapper : EntityMapper<JobProfile>, IProfileMapper
    {
        public ProfileMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}