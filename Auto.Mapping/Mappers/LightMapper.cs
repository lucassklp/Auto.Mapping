namespace Auto.Mapping.Mappers
{
    public abstract class LightMapper<TInput, TOutput> : IMapper<TInput, TOutput>
        where TInput : class
        where TOutput: class, new()
    {
        public abstract TOutput Map(TInput input);

        public object Map(object input) => Map(input as TInput);
    }
}
