using Clients.Core.Common.Entities;
using Clients.Core.Common.ValueObjects;
using OilyTools.Core.Interfaces.UseCases;
using System.Collections.Generic;

namespace Clients.Core.Common.Interfaces.Clients.GetClients
{
    public interface IGetClientsUseCase : IUseCase<ClientsRequest, IEnumerable<Client>>
    {
    }
}
