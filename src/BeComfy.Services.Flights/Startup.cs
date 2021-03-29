using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Services.Flights.EF;
using BeComfy.Common.EFCore;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Jaeger;
using BeComfy.Common.RestEase;
using BeComfy.Services.Flights.Services;
using BeComfy.Common.Mongo;
using BeComfy.Services.Flights.Domain;
using BeComfy.Services.Flights.Messages.Events;

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
            services.AddControllers();
            services.AddJaeger();
            services.AddOpenTracing();
            services.AddMongo();
            services.AddMongoRepository<Flight>("Flights");
            services.AddEFCoreContext<FlightsContext>();
            
            services.RegisterRestClientFor<IAirplanesService>("becomfy-services-airplanes");

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
                .SubscribeCommand<EndFlight>()
                .SubscribeEvent<TicketBought>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
