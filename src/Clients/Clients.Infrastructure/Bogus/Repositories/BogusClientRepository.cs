using Bogus;
using Clients.Core.Common.Entities;
using Clients.Core.Common.Interfaces.Repositories;
using OilyTools.Core.Interfaces.Specifications;
using System.Collections.Generic;
using System.Linq;

namespace Clients.Infrastructure.Bogus.Repositories
{
    public class BogusClientRepository : IClientRepository
    {
        private static int clientIds = 0;

        private static readonly Faker<Client> _clientFaker = new Faker<Client>()
            .UseSeed(386398) // make repeatable sets across builds
            .RuleFor(c => c.Id, _ => clientIds++)
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Name, (_, c) => $"{c.FirstName} {c.LastName}")
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
            .RuleFor(c => c.DateJoined, f => f.Date.Past(5));

        private static readonly IEnumerable<Client> _clients = _clientFaker.Generate(10000);

        public IEnumerable<Client> GetBy(ISpecification<Client> spec = null)
        {
            return SpecificationEvaluator<Client>.ApplySpecification(_clients.AsQueryable(), spec);
        }

        public Client GetById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }
    }
}
