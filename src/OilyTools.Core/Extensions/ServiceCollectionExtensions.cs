using Microsoft.Extensions.DependencyInjection.Extensions;
using OilyTools.Core.DomainEvents.Dispatchers;
using OilyTools.Core.Interfaces.DomainEvents.Dispatchers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainEventDispatcher(this IServiceCollection services)
        {
            services.TryAddScoped<IDomainEventDispatcher, DomainEventDispatcher>();
            return services;
        }
    }
}
