using Clients.Core.Entities;
using OilyTools.Core.Interfaces.Repositories;
using Paginator;
using System;

namespace Clients.Core.Interfaces.Repositories
{
    public interface IClientRepository :
        IBaseReadOnlyRepository<int, Client, CursorPagingRequest, CursorPagingMetadata>
    {
    }
}
