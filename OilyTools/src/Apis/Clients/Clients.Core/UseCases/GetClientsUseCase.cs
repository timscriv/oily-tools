using Clients.Core.Entities;
using Clients.Core.Interfaces.Repositories;
using Clients.Core.Interfaces.UseCases;
using Clients.Core.Specifications;
using Clients.Core.ValueObjects;
using OilyTools.Core.Interfaces.Specifications;
using Paginator;

namespace Clients.Core.UseCases
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
        public IPagingResult<Client, CursorPagingMetadata> Execute(ClientsRequest request)
        {
            //If this gets much larger we could pull out into a factory
            var spec = new ClientsFilterSpecification(request);

            return _clientRepository.GetBy(spec);
        }
    }
}
