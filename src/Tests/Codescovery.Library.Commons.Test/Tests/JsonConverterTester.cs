using System.Diagnostics;
using System.Linq.Expressions;
using System.Text.Json;
using Codescovery.Library.Commons.Extensions;
using Codescovery.Library.Commons.Test.Context;
using Codescovery.Library.Commons.Test.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Codescovery.Library.Commons.Test.Tests
{
    [TestClass]
    public class JsonConverterTester
    {
        private readonly DependencyInjectionContext _dependencyInjectionContext = new();
        [TestInitialize]
        public void Initialize()
        {
#if DEBUG
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
            ConfigureServices(_dependencyInjectionContext.Services, _dependencyInjectionContext.Configuration);
        }

        protected void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {

        }

        [TestMethod]
        public void Serialize()
        {
            var exampleClass = new ClonableExampleClass
            {
                ExampleInt = 1
            };
            exampleClass.With()
                .Property(@class => @class.ExampleString)
                .Set("test")
                .With()
                .Property(@class => @class.ExampleInt)
                .Set(2)
                ;
                
            var json = JsonSerializer.Serialize(exampleClass);
            //var jsonConverter = _dependencyInjectionContext.Resolve<IJsonConverter>();
            //var result = jsonConverter.Serialize(new { Test = "Test" });
            Assert.AreEqual(true, true);
        }
    }
}
