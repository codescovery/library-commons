using System.Diagnostics;
using Codescovery.Library.Commons.Builders;
using Codescovery.Library.Commons.Extensions;
using Codescovery.Library.Commons.Test.Entities;
using Codescovery.Library.Commons.Test.Helpers;

namespace Codescovery.Library.Commons.Test.Tests;
[TestClass]
public class ObjectExtensions
{

    public void Initialize()
    {
#if DEBUG
        Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
#endif
    }
    [TestMethod]
    //[DynamicData(nameof(ObjectHelper.GetNullableTrue), DynamicDataSourceType.Method)]
    //[DataRow(typeof(ClonableExampleClass,null))]
    public void IsNullOrDefaultTrue()
    {
        var typesData = ObjectHelper.GetNullableTrue();
        var randomizer = DeepRandomizerServiceBuilder.BuildDefault();
        var list = new List<object>();
        foreach (var typeData in typesData)
            list.Add(randomizer.Randomizer(typeData.Type));
        Assert.IsTrue(true);
    }
}