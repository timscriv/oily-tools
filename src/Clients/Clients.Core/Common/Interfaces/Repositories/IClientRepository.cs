using Clients.Core.Common.Entities;
using OilyTools.Core.Interfaces.Repositories;

namespace Clients.Core.Common.Interfaces.Repositories
{
    public interface IClientRepository :
        IBaseReadOnlyRepository<int, Client>
    {
    }
}
