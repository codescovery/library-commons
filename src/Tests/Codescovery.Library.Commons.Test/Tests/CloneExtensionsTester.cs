using Codescovery.Library.Commons.Test.Enums;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Codescovery.Library.Commons.Builders;
using Codescovery.Library.Commons.Extensions;
using Codescovery.Library.Commons.Test.Entities;

namespace Codescovery.Library.Commons.Test.Tests
{

    [TestClass]
    public class CloneExtensionsTester
    {
        [TestInitialize]
        public void Initialize()
        {
#if DEBUG
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
        }

        [TestMethod]
        public void DeepClone()
        {
            var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
            var originalObject = randomizer.Randomize<ClonableExampleClass>(4);
            var originalJson = JsonSerializer.Serialize(originalObject);
            var clonedObject = originalObject.DeepClone();
            var clonedJson = JsonSerializer.Serialize(clonedObject);

            Assert.AreEqual(originalJson, clonedJson);
        }
        [TestMethod]
        public void NullDeepClone()
        {
            ClonableExampleClass? originalObject = null;
            var clonedObject = originalObject.DeepClone();

            Assert.AreEqual(clonedObject, default);
        }
    }
}