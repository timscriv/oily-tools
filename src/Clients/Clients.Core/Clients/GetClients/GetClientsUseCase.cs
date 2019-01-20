using Clients.Core.Common.Entities;
using Clients.Core.Common.Interfaces.Clients.GetClients;
using Clients.Core.Common.Interfaces.Repositories;
using Clients.Core.Common.ValueObjects;
using System.Collections.Generic;

namespace Clients.Core.Clients.GetClients
{
    public class GetClientsUseCase : IGetClientsUseCase
    {
        private readonly IClientRepository _clientRepository;

        public GetClientsUseCase(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        /// <summary>
        /// This UseCase shows use of the specification pattern instead of building extra functions (like the GetProductUseCase),
        /// which changes the interface/implementation of the lower layers.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public IEnumerable<Client> Execute(ClientsRequest request)
        {
            //If this gets much larger we could pull out into a factory
            var spec = new GetClientsSpecification(request);

            return _clientRepository.GetBy(spec);
        }
    }
}
