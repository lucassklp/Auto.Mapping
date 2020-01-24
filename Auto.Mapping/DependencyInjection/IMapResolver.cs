using System;
using System.Collections.Generic;
using System.Text;

namespace Auto.Mapping.DependencyInjection
{
    public interface IMapResolver
    {
        IMapper<TInput, TOutput> GetMapper<TInput, TOutput>()
            where TInput : class
            where TOutput: class, new();

        IMapper GetMapper(Type mapType);

        TOutput Map<TInput, TOutput>(TInput input)
            where TInput : class
            where TOutput : class, new();
    }
}
