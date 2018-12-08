using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Converters
{
    public interface IConverter<TEntity, TDto>
    {
        TDto Convert(TEntity entity);
        TEntity Convert(TDto dto);

        IEnumerable<TDto> Convert(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> Convert(IEnumerable<TDto> dtos);
    }
}
