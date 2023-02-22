using Codescovery.Library.Commons.Interfaces.Configuration;
using Codescovery.Library.Commons.Test.Enums;

namespace Codescovery.Library.Commons.Test.Entities
{
    public class ClonableExampleClass
    {


        public string? ExampleString { get; set; } = default;
        public int ExampleInt { get; set; } = default;
        public ExampleEnum ExampleEnum { get; set; } = default;
        public ClonableExampleClass? ExampleNestedClass { get; set; }
        public List<ClonableExampleClass>? ExampleList { get; set; }
    }
}
