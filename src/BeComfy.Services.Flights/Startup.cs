using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.EF;
using BeComfy.Common.EFCore;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Jaeger;

namespace BeComfy.Services.Flights
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer Container { get; private set; } 

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddJaeger();
            services.AddOpenTracing();
            services.AddEFCoreContext<FlightsContext>();

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddHandlers();
            builder.AddDispatcher();

            Container = builder.Build();

            return new AutofacServiceProvider(Container); 
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseRabbitMq()
                .SubscribeCommand<CreateFlight>()
                .SubscribeCommand<DeleteFlight>()
                .SubscribeCommand<EndFlight>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
