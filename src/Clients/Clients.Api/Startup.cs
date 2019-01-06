using Clients.Core.Interfaces.Repositories;
using Clients.Core.Interfaces.UseCases;
using Clients.Core.UseCases;
using Clients.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Clients.Api.Converters;
using OilyTools.Core.Converters;
using Clients.Api.Dtos;
using Clients.Core.Entities;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //UseCases
            services
                .AddScoped<IGetClientsUseCase, GetClientsUseCase>();

            //repositories
            services
                .AddScoped<IClientRepository, BogusClientRepository>();

            //converters
            services
                .AddScoped<IConverter<Client, ClientDto>, ClientConverter>();

            services
                .AddAutoMapper()
                .AddSwaggerGen(c => c.SwaggerDoc("v1", new Info { Title = "Clients API", Version = "v1" }));
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app
                .UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin())
                .UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Clients API V1"))
                .UseHttpsRedirection()
                .UseMvc();
        }
    }
}
