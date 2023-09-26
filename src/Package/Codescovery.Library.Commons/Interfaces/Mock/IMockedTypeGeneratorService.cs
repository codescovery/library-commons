using System;

namespace Codescovery.Library.Commons.Interfaces.Mock
{
    public interface IMockedTypeGeneratorService
    {
        object? CreateMockedObject(Type? type);

    }
    //public class Mocked<T> : T
    //{
    //    public Mocked()
    //    {
    //        var properties = typeof(T).GetProperties();
    //        foreach (var property in properties)
    //        {
    //            property.SetValue(this, "Mocked value");
    //        }
    //    }
    //}
}