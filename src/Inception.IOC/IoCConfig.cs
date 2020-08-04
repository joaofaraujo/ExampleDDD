using EventBus.Domain;
using EventBus.RabbitMQ;
using Inception.Application.Events.Entities;
using Inception.Application.Events.Handlers;
using Inception.Application.Interfaces;
using Inception.Application.Services;
using Inception.CrossCutting.EventsDomain.Entities;
using Inception.CrossCutting.EventsDomain.Notificacoes.Notifications;
using Inception.CrossCutting.EventsDomain.Notificacoes.Notifications.Handlers;
using Inception.Data.Contexts;
using Inception.Data.Repositories;
using Inception.Domain.Interfaces.Repositories;
using Inception.Domain.Interfaces.Services;
using Inception.Domain.Services;
using Inception.FileWatch;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Inception.IOC
{
    public sealed class IoCConfig
    {
        public static void RegisterServices(IServiceCollection services)
        {
            RegisterDomain(services);
            RegisterRepository(services);
            RegisterApplication(services);

            RegisterFileWatch(services);

            var serviceProvider = services.BuildServiceProvider();
            RegisterRabbitMQEvents(services, serviceProvider);

            services.AddScoped<IDomainNotificationHandler<NotificationsDomain>, NotificationsDomainHandler>();

            EventDomain.Container = new ContainerWeb(services);
            serviceProvider.GetService<FileWatchService>();
        }

        private static void RegisterFileWatch(IServiceCollection services)
        {
            services.AddScoped<IIntegrationEventHandler<ProblemaIntegrationEvent>, ProblemaIntegrationEventHandler>();
            services.AddSingleton(sp =>
            {
                return new FileWatchService(sp.GetRequiredService<IIntegrationEventHandler<ProblemaIntegrationEvent>>());
            });
        }

        private static void RegisterApplication(IServiceCollection services)
        {
            services.AddScoped<IInceptionsAppService, InceptionsAppService>();
        }

        private static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped<InceptionContext>();
            services.AddScoped<IInceptionsRepository, InceptionsRepository>();
        }

        private static void RegisterDomain(IServiceCollection services)
        {
            services.AddScoped<IInceptionsService, InceptionsService>();
        }

        private static void RegisterRabbitMQEvents(IServiceCollection services, ServiceProvider serviceProvider)
        {
            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddSingleton<IRabbitMQPersistentConnection, DefaultRabbitMQPersistentConnection>();
            
            services.AddScoped<IIntegrationEventHandler<NecessidadeIntegrationEvent>, NecessidadeIntegrationEventHandler>();

            Action<Type, Type, object> action = delegate (Type handler, Type eventType, object integrationEvent)
            {
                serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    Type concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                    var service = scope.ServiceProvider.GetService(handler);
                    concreteType.GetMethod("Handle").Invoke(service, new object[] { integrationEvent });
                }
            };

            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp =>
            {
                var rabbitMQConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var subscriptionManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();
                var configEventBus = sp.GetRequiredService<ConfigurationEventBus>();
                var logEventBus = sp.GetRequiredService<ILogEventBus>();

                return new EventBusRabbitMQ(rabbitMQConnection, subscriptionManager, action, configEventBus, logEventBus);
            });
        }

        public static void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();

            eventBus.Subscribe<NecessidadeIntegrationEvent, IIntegrationEventHandler<NecessidadeIntegrationEvent>>("NECESSIDADE.BATCH");
        }
    }
}
