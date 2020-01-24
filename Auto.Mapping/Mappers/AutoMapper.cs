using Auto.Mapping.DependencyInjection;
using System;
using System.Linq;

namespace Auto.Mapping.Mappers
{
    public class AutoMapper<TInput, TOutput> : IMapper<TInput, TOutput>
        where TInput : class
        where TOutput: class, new()
    {

        private readonly IMapResolver mapResolver;
        public AutoMapper(IMapResolver mapResolver)
        {
            this.mapResolver = mapResolver;
        }

        public object Map(object input) => Map(input as TInput);

        public TOutput Map(TInput input)
        {
            var outputInstance = new TOutput();
            var outputType = typeof(TOutput);
            var inputType = typeof(TInput);

            var inputProperties = inputType.GetProperties().ToDictionary(x => x.Name);
            var outputProperties = outputType.GetProperties().ToDictionary(x => x.Name);
            
            foreach(var outputProperty in outputProperties)
            {
                if(inputProperties.ContainsKey(outputProperty.Key))
                {
                    var inputProperty = inputProperties[outputProperty.Key];
                    if(inputProperty != null)
                    {
                        if(outputProperty.Value.PropertyType == inputProperty.PropertyType)
                        {
                            outputProperty.Value.SetValue(outputInstance, inputProperty.GetValue(input));
                        }
                        else
                        {
                            try
                            {
                                outputProperty.Value.SetValue(outputInstance, Convert.ChangeType(inputProperty.GetValue(input), outputType));
                            }
                            catch
                            {
                                var automapperType = typeof(IMapper<,>);
                                Type[] typeArgs = { inputProperty.PropertyType, outputProperty.Value.PropertyType };

                                var generictype = automapperType.MakeGenericType(typeArgs);

                                var sonMapper = mapResolver.GetMapper(generictype);
                                var value = sonMapper.Map(inputProperty.GetValue(input));
                                outputProperty.Value.SetValue(outputInstance, value);
                            }
                        }
                    }
                }
            }
            
            return outputInstance;
        }
    }
}
