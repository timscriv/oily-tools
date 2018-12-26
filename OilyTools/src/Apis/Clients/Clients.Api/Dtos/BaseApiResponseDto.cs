using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Paginator;

namespace Clients.Api.Dtos
{
    public abstract class BaseApiResponseDto<TMetadata>
    {
        public TMetadata Metadata { get; set; }
    }
}
