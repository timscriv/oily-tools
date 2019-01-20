using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OilyTools.Core.Converters
{
    public abstract class BaseConverter<TEntity, TDto> : IConverter<TEntity, TDto>
    {
        public abstract TDto Convert(TEntity entity);

        public abstract TEntity Convert(TDto dto);

        public virtual IEnumerable<TDto> Convert(IEnumerable<TEntity> entities)
        {
            return entities?.Select(e => Convert(e));
        }

        public virtual IEnumerable<TEntity> Convert(IEnumerable<TDto> dtos)
        {
            return dtos?.Select(e => Convert(e));
        }
    }
}
