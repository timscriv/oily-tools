using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Converters
{
    public interface IConverter<TEntity, TDto>
    {
        IEnumerable<TEntity> ConvertToEntities(IEnumerable<TDto> dtos);
        TEntity ConvertToEntity(TDto dto);

        IEnumerable<TDto> ConvertToDtos(IEnumerable<TEntity> entities);
        TDto ConvertToDto(TEntity entity);
    }
}
