using Auto.Mapping.Tests.Models.Simple;

namespace Auto.Mapping.Tests.Models.Nested
{
    public class FatherA : ModelA
    {
        public SonA Son {get;set;}
    }
}
