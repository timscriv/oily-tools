using Clients.Core.Common.Entities;
using Clients.Core.Common.ValueObjects;
using OilyTools.Core.Specifications;

namespace Clients.Core.Clients.GetClients
{
    public class GetClientsSpecification : BaseSpecification<Client>
    {
        //TODO: Fix year and lastName filter
        public GetClientsSpecification(ClientsRequest request)
            : base()
        {
            AddPaging(request.Limit, request.Offset);
        }
    }
}
