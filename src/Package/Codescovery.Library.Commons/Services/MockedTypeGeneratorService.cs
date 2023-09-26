using Codescovery.Library.Commons.Interfaces.Mock;
using System;

namespace Codescovery.Library.Commons.Services
{
    internal class MockedTypeGeneratorService : IMockedTypeGeneratorService
    {
        public object? CreateMockedObject(Type? type)
        {
            if (type == null) return null;
            var mockedType = typeof(IMock).MakeGenericType(type);
            return Activator.CreateInstance(mockedType);

        }
    }
}