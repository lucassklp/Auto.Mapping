using Auto.Mapping.DependencyInjection;
using Auto.Mapping.Tests.Models.Simple;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Auto.Mapping.Tests
{
    public class InjectionTests
    {
        private Injector injector;
        public InjectionTests()
        {
            this.injector = new Injector();
            injector.ConfigureServices(services => 
            {
                services.AddAutoMapping();
                services.AddAutoMapper<ModelA, ModelB>();
            }).Build();
        }

        [Fact]
        public void TestMapResolver()
        {
            var mapResolver = injector.Get<IMapResolver>();

            Assert.NotNull(mapResolver);
        }

        [Fact]
        public void TestAutoMappingInjected()
        {
            var mapResolver = injector.Get<IMapResolver>();

            var mapper = mapResolver.GetMapper<ModelA, ModelB>();

            Assert.NotNull(mapper);
        }
    }
}
