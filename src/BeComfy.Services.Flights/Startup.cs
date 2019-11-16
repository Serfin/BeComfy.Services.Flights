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

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson();

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
