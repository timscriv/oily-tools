using Microsoft.Extensions.DependencyInjection.Extensions;
using OilyTools.Core.Interfaces;
using Products.Core.Common.DomainEvents;
using Products.Core.Common.Handlers;
using Products.Core.Common.Interfaces.Products.CreateProduct;
using Products.Core.Common.Interfaces.Products.GetProduct;
using Products.Core.Common.Interfaces.Products.GetProducts;
using Products.Core.Products.CreateProduct;
using Products.Core.Products.GetProduct;
using Products.Core.Products.GetProducts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainEventHandlers(this IServiceCollection services)
        {
            services.TryAddScoped<IHandle<ProductCreatedEvent>, ProductHandler>();
            services.TryAddScoped<IHandle<ProductPriceChangedEvent>, ProductHandler>();

            return services;
        }

        public static IServiceCollection AddProductUseCases(this IServiceCollection services)
        {
            services.TryAddScoped<IGetProductsUseCase, GetProductsUseCase>();
            services.TryAddScoped<IGetProductUseCase, GetProductUseCaseCached>();
            services.TryAddScoped<GetProductUseCase>();
            services.TryAddScoped<ICreateProductUseCase, CreateProductUseCase>();

            return services;
        }
    }
}
