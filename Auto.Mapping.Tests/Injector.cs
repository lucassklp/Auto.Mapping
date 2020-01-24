using Auto.Mapping.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Auto.Mapping.Tests
{
    class Injector
    {
        private ServiceCollection serviceCollection;
        private ServiceProvider serviceProvider;
        private Action<ServiceCollection> servicesAction;
        public Injector()
        {
            serviceCollection = new ServiceCollection();
        }

        public ServiceProvider Build()
        {
            servicesAction.Invoke(serviceCollection);
            serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        public Injector ConfigureServices(Action<ServiceCollection> services)
        {
            this.servicesAction = services;
            return this;
        }

        public T Get<T>()
        {
            return this.serviceProvider.GetService<T>();
        }

        public IMapper<TInput, TOutput> GetMapper<TInput, TOutput>()
            where TInput : class
            where TOutput: class, new()
        {
            return this.serviceProvider.GetService<IMapResolver>().GetMapper<TInput, TOutput>();
        }

    }
}
