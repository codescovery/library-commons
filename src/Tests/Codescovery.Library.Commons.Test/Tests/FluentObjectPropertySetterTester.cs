using System.Diagnostics;
using Codescovery.Library.Commons.Builders;
using Codescovery.Library.Commons.Extensions;
using Codescovery.Library.Commons.Test.Entities;
using Codescovery.Library.Commons.Test.Helpers;

namespace Codescovery.Library.Commons.Test.Tests;
[TestClass]
public class FluentObjectPropertySetterTester
{

    public void Initialize()
    {
#if DEBUG
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
    }
    [TestMethod]
    public void ChangeString()
    {
        var stringValue = Guid.NewGuid().ToString();
        var exampleClass = new ClonableExampleClass
        {
            ExampleInt = 1
        };
        exampleClass.With()
            .Property(@class => @class.ExampleString)
            .Set(stringValue);
        Assert.AreEqual(exampleClass.ExampleString, stringValue);
    }
    [TestMethod]
    public void ChangeInt()
    {
        var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
        var intValue =  randomizer.Randomize<int>();
        var exampleClass = new ClonableExampleClass
        {
            ExampleInt = 1
        };
        exampleClass.With()
            .Property(@class => @class.ExampleInt)
            .Set(intValue);
        Assert.AreEqual(exampleClass.ExampleInt, intValue);
        
    }
    [TestMethod]
    public void ChangeStringAndInt()
    {
        var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
        var intValue = randomizer.Randomize<int>();
        var stringValue = Guid.NewGuid().ToString();
        var exampleClass = new ClonableExampleClass
        {
            ExampleInt = 1
        };
       exampleClass.With()
            .Property(@class => @class.ExampleInt)
            .Set(intValue)
            .And()
            .Property(@class => @class.ExampleString)
            .Set(stringValue);
        Assert.AreEqual(exampleClass.ExampleInt, intValue);
        Assert.AreEqual(exampleClass.ExampleString, stringValue);

    }
    [TestMethod]
    public void CloneWithChangeStringAndInt()
    {
        var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
        var intValue = randomizer.Randomize<int>();
        var stringValue = Guid.NewGuid().ToString();
        var exampleClass = new ClonableExampleClass
        {
            ExampleInt = 1
        };
       var cloned= exampleClass.DeepCloneWith()
            .Property(@class => @class.ExampleInt)
            .Set(intValue)
            .And()
            .Property(@class => @class.ExampleString)
            .Set(stringValue);
        Assert.AreEqual(cloned.ExampleInt, intValue);
        Assert.AreNotEqual(exampleClass.ExampleInt, intValue);
        Assert.AreEqual(cloned.ExampleString, stringValue);
        Assert.AreNotEqual(exampleClass.ExampleString, stringValue);

    }
}