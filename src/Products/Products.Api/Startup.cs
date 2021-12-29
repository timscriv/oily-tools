using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using OilyTools.Core.Converters;
using Products.Api.Common.Filters;
using Products.Api.Products.Dtos;
using Products.Core.Common.Entities;
using Products.Core.Products.Converters;

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
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(CustomExceptionFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
            });

            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            //Core
            services
                .AddDomainEventDispatcher()
                .AddProductUseCases()
                .AddDomainEventHandlers();

            //Infrastructure
            services
                .AddEntityFrameworkSqliteSuite("Data Source=../../../oilytools.db");

            services
                .AddScoped<IConverter<Product, ProductDto>, ProductConverter>();

            services
                .AddOpenApiDocument();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
                .UseRouting()
                .UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
                .UseOpenApi()
                .UseSwaggerUi3()
                .UseHttpsRedirection()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
