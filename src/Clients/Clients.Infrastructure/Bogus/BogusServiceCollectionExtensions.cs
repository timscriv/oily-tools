using Clients.Core.Common.Interfaces.Repositories;
using Clients.Infrastructure.Bogus.Repositories;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class BogusServiceCollectionExtensions
    {
        public static IServiceCollection AddBogusClientSuite(this IServiceCollection services)
        {
            services.TryAddScoped<IClientRepository, BogusClientRepository>();

            return services;
        }
    }
}
