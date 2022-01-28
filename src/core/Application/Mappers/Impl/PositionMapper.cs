using AutoMapper;
using Domain.Models;

namespace Application.Mappers.Impl
{
    public class PositionMapper : EntityMapper<JobPosition>, IPositionMapper
    {
        public PositionMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}