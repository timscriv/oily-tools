using Clients.Core.Entities;
using Clients.Core.ValueObjects;
using OilyTools.Core.Interfaces.UseCases;
using System.Collections.Generic;

namespace Clients.Core.Interfaces.UseCases
{
    public interface IGetClientsUseCase : IUseCase<ClientsRequest, IEnumerable<Client>>
    {
    }
}
