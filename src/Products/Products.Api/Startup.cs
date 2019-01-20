using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OilyTools.Core.Converters;
using Products.Api.Common.Filters;
using Products.Api.Products.Dtos;
using Products.Core.Common.Entities;
using Products.Core.Products.Converters;
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
