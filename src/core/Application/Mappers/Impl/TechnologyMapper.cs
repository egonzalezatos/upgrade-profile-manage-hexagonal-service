using AutoMapper;
using Domain.Models;

namespace Application.Mappers.Impl
{
    public class TechnologyMapper : EntityMapper<Technology>, ITechnologyMapper
    {
        public TechnologyMapper(IMapper mapper) : base(mapper)
        {
        }
    }
}