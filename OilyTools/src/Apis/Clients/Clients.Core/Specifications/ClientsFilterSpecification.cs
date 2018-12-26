using Clients.Core.Entities;
using Clients.Core.ValueObjects;
using OilyTools.Core.Specifications;
using Paginator;
using System.Linq.Expressions;

namespace Clients.Core.Specifications
{
    public class ClientsFilterSpecification : BaseSpecification<Client>
    {
        //TODO: Fix year and lastName filter
        public ClientsFilterSpecification(ClientsRequest request)
            : base()
        {
        }
    }
}
