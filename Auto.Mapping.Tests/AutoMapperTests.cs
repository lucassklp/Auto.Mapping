using Auto.Mapping.DependencyInjection;
using Auto.Mapping.Mappers;
using Auto.Mapping.Tests.Models.Nested;
using Auto.Mapping.Tests.Models.Simple;
using Xunit;

namespace Auto.Mapping.Tests
{
    public class AutoMapperTests
    {
        private readonly Injector injector;
        public AutoMapperTests()
        {
            injector = new Injector();
        }

        [Fact]
        public void SimpleMapping()
        {
            injector.ConfigureServices(services => 
            {
                services.AddAutoMapping();
                services.AddAutoMapper<ModelA, ModelB>();
            }).Build();

            var autoMapper = injector.GetMapper<ModelA, ModelB>();

            var modelA = new ModelA()
            {
                Id = 12,
                Age = 22,
                Name = "Lucas"
            };

            var modelB = autoMapper.Map(modelA);

            Assert.Equal(modelA.Id, modelB.Id);
        }

        [Fact]
        public void NestedMapping()
        {
            injector.ConfigureServices(services => 
            {
                services.AddAutoMapping();
                services.AddAutoMapper<FatherA, FatherB>();
                services.AddAutoMapper<SonA, SonB>();
            }).Build();

            var autoMapper = injector.GetMapper<FatherA, FatherB>();

            var modelA = new FatherA()
            {
                Id = 12,
                Age = 22,
                Name = "Lucas",
                Son = new SonA()
                {
                    Reference = "12346",
                    Quantity = 5
                }
            };

            var modelB = autoMapper.Map(modelA);

            Assert.Equal(modelB.Son.Quantity, modelA.Son.Quantity);
        }
    }
}
