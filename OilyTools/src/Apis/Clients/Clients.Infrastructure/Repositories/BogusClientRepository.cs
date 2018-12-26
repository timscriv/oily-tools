using Bogus;
using Clients.Core.Entities;
using Clients.Core.Interfaces.Repositories;
using OilyTools.Core.Interfaces.Specifications;
using Paginator;
using Paginator.Cursors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Clients.Infrastructure.Repositories
{
    public class BogusClientRepository : IClientRepository
    {
        private static int clientIds = 0;

        private static readonly Faker<Client> _clientFaker = new Faker<Client>()
            .UseSeed(386398) // make repeatable sets across builds
            .RuleFor(c => c.Id, f => clientIds++)
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName())
            .RuleFor(c => c.Name, (f, c) => $"{c.FirstName} {c.LastName}")
            .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
            .RuleFor(c => c.DateJoined, f => f.Date.Past(5));

        private static readonly IEnumerable<Client> _clients = _clientFaker.Generate(10000);

        public IPagingResult<Client, CursorPagingMetadata> GetBy(ISpecification<Client> spec = null, CursorPagingRequest pagingRequest = null)
        {
            var data = SpecificationEvaluator<Client>.ApplySpecification(_clients.AsQueryable(), spec);

            var cursor = new KeyCursor<Client, int>(pagingRequest.Cursor);
            var options = new KeyCursorOptions<Client, int>(c => c.Id > cursor.Key, c => c.Id, pagingRequest.Limit);

            return cursor.ApplyCursor(data, options);
        }

        public Client GetById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }
    }
}
