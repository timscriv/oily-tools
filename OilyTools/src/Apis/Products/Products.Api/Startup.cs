using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OilyTools.Core.Converters;
using OilyTools.Core.DomainEvents.Dispatchers;
using OilyTools.Core.Interfaces;
using OilyTools.Core.Interfaces.DomainEvents.Dispatchers;
using Products.Api.Dtos;
using Products.Api.Filters;
using Products.Core.Converters;
using Products.Core.DomainEvents;
using Products.Core.Entities;
using Products.Core.Handlers;
using Products.Core.Interfaces.Repositories;
using Products.Core.Interfaces.UseCases.Products;
using Products.Core.UseCases.Products;
using Products.Infrastructure.Contexts;
using Products.Infrastructure.Repositories;
using Swashbuckle.AspNetCore.Swagger;

namespace Products.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
            }).AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ProductsContext>(options => options.UseSqlite("Data Source=../../../../oilytools.db"));

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services
                .AddScoped<IGetProductsUseCase, GetProductsUseCase>()
                .AddScoped<IGetProductUseCase, GetProductUseCaseCached>()
                .AddScoped<GetProductUseCase>()
                .AddScoped<ICreateProductUseCase, CreateProductUseCase>()
                .AddScoped<IProductReadOnlyRepository, ProductCachedRepository>()
                .AddScoped<ProductRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IHistoricalPriceRepository, HistoricalPriceRepository>()
                .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddScoped<IConverter<Product, ProductDto>, ProductConverter>()
                .AddScoped(typeof(IHandle<ProductCreatedEvent>), typeof(ProductHandler))
                .AddScoped(typeof(IHandle<ProductPriceChangedEvent>), typeof(ProductHandler))
                .AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "Products API", Version = "v1" }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app
                .UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API V1"))
                .UseHttpsRedirection()
                .UseMvc();
        }
    }
}
