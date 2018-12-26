using Clients.Core.Entities;
using Clients.Core.ValueObjects;
using OilyTools.Core.Interfaces.UseCases;
using Paginator;

namespace Clients.Core.Interfaces.UseCases
{
    public interface IGetClientsUseCase : IUseCase<ClientsRequest, IPagingResult<Client, CursorPagingMetadata>>
    {
    }
}
