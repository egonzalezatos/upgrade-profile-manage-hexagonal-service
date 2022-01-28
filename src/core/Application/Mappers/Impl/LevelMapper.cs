using AutoMapper;
using Domain.Models;

namespace Application.Mappers.Impl
{
    public class LevelMapper : EntityMapper<Level>, ILevelMapper
    {
        public LevelMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}