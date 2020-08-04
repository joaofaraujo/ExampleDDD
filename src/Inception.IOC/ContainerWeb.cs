using Inception.CrossCutting.EventsDomain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Inception.IOC
{
    public class ContainerWeb : IContainer
    {
        private readonly ServiceProvider _serviceProvider;

        public ContainerWeb(IServiceCollection services)
        {
            _serviceProvider = services.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return (T)_serviceProvider.GetService(typeof(T));
        }

        public object GetService(Type serviceType)
        {
            return _serviceProvider.GetService(serviceType);
        }

        public IEnumerable<T> GetServices<T>()
        {
            return (IEnumerable<T>)_serviceProvider.GetServices(typeof(T));
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _serviceProvider.GetServices(serviceType);
        }
    }
}
