using Clients.Core.Entities;
using OilyTools.Core.Interfaces.Repositories;

namespace Clients.Core.Interfaces.Repositories
{
    public interface IClientRepository :
        IBaseReadOnlyRepository<int, Client>
    {
    }
}
