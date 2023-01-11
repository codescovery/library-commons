using System.Diagnostics;
using System.Reflection;
using System.Text;
using Codescovery.Library.Commons.Exceptions;
using Codescovery.Library.Commons.Extensions;
using Codescovery.Library.Commons.Helpers;
using Codescovery.Library.Commons.Test.Enums;

namespace Codescovery.Library.Commons.Test.Tests
{
    [TestClass]
    public class EnumExtensionsTester
    {
        [TestInitialize]
        public void Initialize()
        {
#if DEBUG
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
        }
        [TestMethod]
        [DataRow(ExampleEnum.Value1, 1)]
        [DataRow(ExampleEnum.Value2, 5)]
        public void ToNullableInt(ExampleEnum value, int? expectedMessageResult)
        {
            var result = value.ToNullableInt();
            Assert.AreEqual(expectedMessageResult, result);
        }
        [TestMethod]
        [DataRow(ExampleEnum.Value1, 1)]
        [DataRow(ExampleEnum.Value2, 5)]
        public void ToInt(ExampleEnum value, int? expectedMessageResult)
        {
            var result = value.ToInt();
            Assert.AreEqual(expectedMessageResult, result);
        }
    }
}