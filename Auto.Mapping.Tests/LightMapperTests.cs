using Auto.Mapping.Tests.Implementation;
using Auto.Mapping.Tests.Models.Simple;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Auto.Mapping.Tests
{
    
    public class LightMapperTests
    {
        [Fact]
        public void TestingLightMapper()
        {
            var mapper = new SimpleMapper();
            var modelA = new ModelA
            {
                Age = 22,
                Id = 20,
                Name = "Arnold"
            };

            var modelB = mapper.Map(modelA);

            Assert.Equal(modelA.Id, modelB.Id);
        }
    }
}
