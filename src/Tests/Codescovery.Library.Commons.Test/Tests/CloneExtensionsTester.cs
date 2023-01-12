using Codescovery.Library.Commons.Test.Enums;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
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
            ClonableExampleClass CreateNewItem(ClonableExampleClass? nestedClass=null,bool addNestedClassToList=true, int generatedItemsInList=1)
            {
                var list = addNestedClassToList && !nestedClass.IsNullOrDefault()? new List<ClonableExampleClass>{nestedClass} : null;
                return new ClonableExampleClass
                {
                    ExampleInt = 3,
                    ExampleString = "ExampleString",
                    ExampleEnum = ExampleEnum.Value2,
                    ExampleList = new List<ClonableExampleClass>()
                };
            }

            var exampleNestedClass = new ClonableExampleClass
            {
                ExampleInt = 2,
                ExampleString = "ExampleString2",
                ExampleEnum = ExampleEnum.Value2,
                ExampleList = new List<ClonableExampleClass>()
                {
                    CreateNewItem()
                }
            };
            var originalObject = new ClonableExampleClass
            {
                ExampleInt = 1,
                ExampleString = "ExampleString",
                ExampleEnum = ExampleEnum.Value1,
                ExampleList = new List<ClonableExampleClass>
                {
                    exampleNestedClass,
                    new ClonableExampleClass
                    {
                        ExampleInt = 4,
                        ExampleString = "ExampleString4",
                        ExampleEnum = ExampleEnum.Value2,
                        ExampleList = new List<ClonableExampleClass>()
                    }
                },
                ExampleNestedClass = exampleNestedClass

            };
            var originalJson = JsonSerializer.Serialize(originalObject);
            var clonedObject = originalObject.DeepClone();
            var clonedJson = JsonSerializer.Serialize(clonedObject);

            Assert.AreEqual(originalJson, clonedJson);
        }
    }
}