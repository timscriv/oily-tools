using Paginator;
using System.Collections.Generic;

namespace Clients.Api.Dtos
{
    public class ClientCollectionDto: BaseApiResponseDto<CursorPagingMetadata>
    {
        public List<ClientDto> Clients { get; set; }
    }
}
