using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Mapping.DependencyInjection
{
    public class MapResolver : IMapResolver
    {
        private readonly IServiceProvider provider;

        public MapResolver(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public IMapper<TInput, TOutput> GetMapper<TInput, TOutput>()
            where TInput : class
            where TOutput: class, new()

        {
            return provider.GetService(typeof(IMapper<TInput, TOutput>)) as IMapper<TInput, TOutput>;
        }

        public IMapper GetMapper(Type serviceType)
        {
            var mapper = provider.GetService(serviceType);
            return mapper as IMapper;
        }

        public TOutput Map<TInput, TOutput>(TInput input)
            where TOutput : class, new()
            where TInput : class
        {
            return GetMapper<TInput, TOutput>().Map(input);
        }
    }
}
