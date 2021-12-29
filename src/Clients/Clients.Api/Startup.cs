using AutoMapper;
using Clients.Api.Clients.Converters;
using Clients.Api.Clients.Dtos;
using Clients.Core.Common.Entities;
using Clients.Core.Common.ValueObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OilyTools.Core.Converters;

namespace Clients.Api
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
            services.AddControllers();

            //Core
            services
                .AddDomainEventDispatcher()
                .AddClientUseCases();

            //Infrastructure
            services
                .AddBogusClientSuite();

            services
                .AddScoped<IConverter<Client, ClientDto>, ClientConverter>()
                .AddScoped<IConverter<ClientsRequest, ClientsRequestDto>, ClientsRequestConverter>();

            services
                .AddAutoMapper()
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
