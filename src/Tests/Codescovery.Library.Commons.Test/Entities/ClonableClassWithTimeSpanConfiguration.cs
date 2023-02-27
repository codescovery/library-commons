using Codescovery.Library.Commons.Entities.Configurations;
namespace Codescovery.Library.Commons.Test.Entities;

public class ClonableClassWithTimeSpanConfiguration:ClonableExampleClass
{
    public TimeSpanConfiguration? TimeSpanConfiguration { get; set; }
}