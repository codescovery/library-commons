using Codescovery.Library.Commons.Test.Entities;

namespace Codescovery.Library.Commons.Test.Helpers;

internal static class ObjectHelper
{
    public static IEnumerable<ObjectExtensionsIsNullOrDefaultDynamicItem> GetNullableTrue()=>
    GetNullable(true);
    public static IEnumerable<ObjectExtensionsIsNullOrDefaultDynamicItem> GetNullableFalse() =>
        GetNullable(false);
    public static IEnumerable<ObjectExtensionsIsNullOrDefaultDynamicItem> GetNullable(bool expectedResult)
    {
        return GetTypes().Select(type => new ObjectExtensionsIsNullOrDefaultDynamicItem { ExpectedResult = expectedResult,Type = type });
    }
    public static IEnumerable<Type> GetTypes()
    {
        return new List<Type>
        {
            typeof(ClonableExampleClass),
            typeof(int),
            typeof(double),
            typeof(float),
            typeof(decimal),
            typeof(string),
            typeof(Exception)
        };
    }
}