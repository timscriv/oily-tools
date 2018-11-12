using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OilyTools.Api.Filters;
using OilyTools.Core.Converters;
using OilyTools.Core.DomainEvents.Dispatchers;
using OilyTools.Core.DomainEvents;
using OilyTools.Core.Handlers;
using OilyTools.Core.Persistence;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.EntityFrameworkCore.Design;
using Newtonsoft.Json;
using OilyTools.Core.Services;
using OilyTools.Core.Repositories;
using OilyTools.Core.Entities;

namespace OilyTools.Api
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
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<OilyToolsDbContext>(options => options.UseSqlite("Data Source=../../oilytools.db"));

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services
                .AddScoped<IProductService, ProductService>()
                .AddScoped<ProductRepository>()
                .AddScoped<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddScoped<ProductConverter>()
                .AddScoped(typeof(IHandle<ProductCreatedEvent>), typeof(ProductHandler))
                .AddScoped(typeof(IHandle<ProductPriceChangedEvent>), typeof(ProductHandler))
                .AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "Oily Tools API", Version = "v1" }));
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
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Oily Tools API V1"))
                .UseHttpsRedirection()
                .UseMvc();
        }
    }
}
