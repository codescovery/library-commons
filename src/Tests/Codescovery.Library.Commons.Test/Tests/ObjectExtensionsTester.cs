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
    public class ObjectExtensionsTester
    {
        [TestInitialize]
        public void Initialize()
        {
#if DEBUG
            Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
        }
        
        [TestMethod]
        public void CopyPropertiesFromObjectToAnotherWithModifiedValueNotNull()
        {
            var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
            var sourceObject = randomizer.Randomize<ClonableExampleClass>(4);
            var newObject = new ClonableExampleClass();
            newObject.FillWith(sourceObject);
            newObject.ExampleString = "New string value";
            var newObjectJson = JsonSerializer.Serialize(newObject);
            var sourceObjectJson = JsonSerializer.Serialize(sourceObject);

            Assert.AreNotEqual(newObjectJson, sourceObjectJson);
        }
        [TestMethod]
        public void CopyPropertiesFromObjectToAnotherWithModifiedValueNull()
        {
            ClonableExampleClass? sourceObject = null;
            var newObject = new ClonableExampleClass();
            newObject.FillWith(sourceObject);
            newObject.ExampleString = "New string value";
            var newObjectJson = JsonSerializer.Serialize(newObject);
            var sourceObjectJson = JsonSerializer.Serialize(sourceObject);

            Assert.AreNotEqual(newObjectJson, sourceObjectJson);
        }

        [TestMethod]
        public void CopyPropertiesFromObjectToAnotherWithoutModifiedValueNotNull()
        {
            var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
            var sourceObject = randomizer.Randomize<ClonableExampleClass>(4);
            var newObject = new ClonableExampleClass();
            newObject.FillWith(sourceObject);
            var newObjectJson = JsonSerializer.Serialize(newObject);
            var sourceObjectJson = JsonSerializer.Serialize(sourceObject);

            Assert.AreEqual(newObjectJson, sourceObjectJson);
        }
        [TestMethod]
        public void CopyPropertiesFromObjectToAnotherWithoutModifiedValueNull()
        {
            ClonableExampleClass? sourceObject = null;
            var newObject = new ClonableExampleClass();
            newObject.FillWith(sourceObject);
            var newObjectJson = JsonSerializer.Serialize(newObject);
            var sourceObjectJson = JsonSerializer.Serialize(sourceObject);

            Assert.AreNotEqual(newObjectJson, sourceObjectJson);
        }
        [TestMethod]
        public void CopyPropertiesFromObjectToAnotherWithoutModifiedValueNewObjectNull()
        {
            ClonableExampleClass? sourceObject = null;
            ClonableExampleClass? newObject = null;
            newObject.FillWith(sourceObject);
            var newObjectJson = JsonSerializer.Serialize(newObject);
            var sourceObjectJson = JsonSerializer.Serialize(sourceObject);

            Assert.AreEqual(newObjectJson, sourceObjectJson);
        }
        [TestMethod]
        public void CopyPropertiesFromObjectToAnotherWithoutModifiedValueNewObjectNullSourceObjectNotNull()
        {
            var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
            var sourceObject = randomizer.Randomize<ClonableExampleClass>(4);
            ClonableExampleClass? newObject = null;
            Assert.ThrowsException<ArgumentNullException>(()=>newObject.FillWith(sourceObject));
        }
        [TestMethod]
        public void ObjectWith()
        {
            var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
            var sourceObject = randomizer.Randomize<ClonableExampleClass>(4);
            var sourceObjectString = JsonSerializer.Serialize(sourceObject);
            var newObject = sourceObject.WithValues(new ClonableExampleClass
            {
                ExampleString = "teste",
                ExampleEnum = ExampleEnum.Value2,
                ExampleList = new List<ClonableExampleClass>
                {
                    new ClonableExampleClass{ExampleString = "teste2"}
                }
            });
            Assert.AreNotEqual(sourceObjectString, JsonSerializer.Serialize(newObject));
        }
        [TestMethod]
        public void ObjectWithNewObjectNull()
        {
            var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
            var sourceObject = randomizer.Randomize<ClonableExampleClass>(4);
            var sourceObjectString = JsonSerializer.Serialize(sourceObject);
            
            var newObject = sourceObject.WithValues();
            Assert.AreEqual(sourceObjectString, JsonSerializer.Serialize(newObject));
        }
        [TestMethod]
        public void SourceObjectNullWithNewValues()
        {
            var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
            ClonableExampleClass? sourceObject = null;
            var sourceObjectString = JsonSerializer.Serialize(sourceObject);

            var newObject = sourceObject.WithValues(new ClonableExampleClass
            {
                ExampleString = "teste",
                ExampleEnum = ExampleEnum.Value2,
                ExampleList = new List<ClonableExampleClass>
                {
                    new ClonableExampleClass{ExampleString = "teste2"}
                }
            });
            Assert.AreNotEqual(sourceObjectString, JsonSerializer.Serialize(newObject));
        }
        [TestMethod]
        public void SourceObjectNullWithNewNullValues()
        {
            var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
            ClonableExampleClass? sourceObject = null;
            var sourceObjectString = JsonSerializer.Serialize(sourceObject);

            var newObject = sourceObject.WithValues();
            Assert.AreEqual(sourceObjectString, JsonSerializer.Serialize(newObject));
        }
    }
}