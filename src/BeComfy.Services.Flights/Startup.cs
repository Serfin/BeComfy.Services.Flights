using Autofac;
using Autofac.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BeComfy.Common.RabbitMq;
using BeComfy.Services.Flights.Messages.Commands;
using BeComfy.Common.MSSQL;
using BeComfy.Common.CqrsFlow;
using BeComfy.Services.Flights.Helpers;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                .AsImplementedInterfaces();

            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddHandlers();
            builder.AddDispatcher();
            builder.AddSqlServer();

            Container = builder.Build();

            return new AutofacServiceProvider(Container); 
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

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseRabbitMq().SubscribeCommand<CreateFlight>();
            app.UseRabbitMq().SubscribeCommand<DeleteFlight>();
        }
    }
}
