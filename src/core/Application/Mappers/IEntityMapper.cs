using System.Collections.Generic;
using Domain.Models;

namespace Application.Mappers
{
     public interface IEntityMapper<TEntity>
          where TEntity : Entity

     {
          TDto ToDto<TDto>(TEntity entity);

          List<TDto> ToDto<TDto>(List<TEntity> entity);

          TEntity ToEntity<TDto>(TDto dto);

          List<TEntity> ToEntity<TDto>(List<TDto> dto);
     }
}