using System;

namespace Auto.Mapping
{
    public interface IMapper
    {
        object Map(object input);
    }
}

namespace Auto.Mapping
{
    public interface IMapper<in TInput, out TOutput> : IMapper
    {
        TOutput Map(TInput input);
    }
}
