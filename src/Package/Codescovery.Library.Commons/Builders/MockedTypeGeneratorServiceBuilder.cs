using Codescovery.Library.Commons.Interfaces.Mock;
using Codescovery.Library.Commons.Services;

namespace Codescovery.Library.Commons.Builders
{
    public class MockedTypeGeneratorServiceBuilder
    {
        public static IMockedTypeGeneratorService BuildDefault() => new MockedTypeGeneratorService();
    }
}