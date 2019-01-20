using Clients.Core.Clients.GetClients;
using Clients.Core.Common.Interfaces.Clients.GetClients;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddClientUseCases(this IServiceCollection services)
        {
            services.TryAddScoped<IGetClientsUseCase, GetClientsUseCase>();

            return services;
        }
    }
}
