using System.Collections.Generic;
using AutoMapper;
using Domain.Models;

namespace Application.Mappers.Impl
{
    public class EntityMapper<TEntity> : IEntityMapper<TEntity> where TEntity : Entity
    {
        private readonly IMapper _mapper;

        public EntityMapper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public virtual TDto ToDto<TDto>(TEntity entity)
        {
            return _mapper.Map<TEntity, TDto>(entity);
        }

        public List<TDto> ToDto<TDto>(List<TEntity> entity)
        {
            return _mapper.Map<List<TEntity>, List<TDto>>(entity);
        }

        public virtual TEntity ToEntity<TDto>(TDto dto)
        {
            return _mapper.Map<TDto, TEntity>(dto);
        }

        public List<TEntity> ToEntity<TDto>(List<TDto> dto)
        {
            return _mapper.Map<List<TDto>, List<TEntity>>(dto);
        }
    }
}