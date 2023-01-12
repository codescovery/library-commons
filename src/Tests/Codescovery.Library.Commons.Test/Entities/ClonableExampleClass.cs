using Codescovery.Library.Commons.Test.Enums;

namespace Codescovery.Library.Commons.Test.Entities
{
internal class ClonableExampleClass
{
    public ClonableExampleClass()
    {
        
    }
    public string ExampleString { get; set; }
    public int ExampleInt { get; set; }
    public ExampleEnum ExampleEnum { get; set; }
    public ClonableExampleClass ExampleNestedClass { get; set; }
    public List<ClonableExampleClass> ExampleList { get; set; }
}
}
