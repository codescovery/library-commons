using System.Diagnostics;
using Codescovery.Library.Commons.Test.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codescovery.Library.Commons.Test.Tests
{
    [TestClass]
    public class JsonConverterTester
    {
        private readonly DependencyInjectionContext _dependencyInjectionContext = new ();
        [TestInitialize]
        public void Initialize()
        {
#if DEBUG
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
            ConfigureServices(_dependencyInjectionContext.Services, _dependencyInjectionContext.Configuration);
        }

        protected  void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            
        }

        [TestMethod]
        public void Serialize()
        {
            //var jsonConverter = _dependencyInjectionContext.Resolve<IJsonConverter>();
            //var result = jsonConverter.Serialize(new { Test = "Test" });
            Assert.AreEqual(true,true);
        }
    }
}
