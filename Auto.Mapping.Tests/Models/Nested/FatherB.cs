using Auto.Mapping.Tests.Models.Simple;

namespace Auto.Mapping.Tests.Models.Nested
{
    public class FatherB : ModelA
    {
        public SonB Son {get;set;}
    }
}
