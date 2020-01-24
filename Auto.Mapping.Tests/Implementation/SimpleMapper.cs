using Auto.Mapping.Mappers;
using Auto.Mapping.Tests.Models.Simple;
using System;

namespace Auto.Mapping.Tests.Implementation
{
    public class SimpleMapper : LightMapper<ModelA, ModelB>
    {
        public override ModelB Map(ModelA input)
        {
            return new ModelB
            {
                Age = input.Age,
                Id = input.Id,
                Name = input.Name
            };
        }
    }
}
