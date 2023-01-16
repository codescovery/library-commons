using Codescovery.Library.Commons.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Codescovery.Library.Commons.Interfaces
{
    public interface IDeepRandomizerService
    {
        object Randomize(Type type, int maxDepth = 1);
        T Randomize<T>(int maxDepth = 1);



        T HandleArray<T>(Type type, int maxDepth = 1);

        bool HandleGenericType<T>(Type type, out T resultList, int maxDepth = 1);

        void AddValuesToEnumerable<T>(T obj, int maxDepth = 1);


        void HandleAdd<T>(T obj, MethodInfo addMethod, int maxDepth = 1);

        void PropertySetter(Type type, object obj, int maxDepth = 1);

        object RandomizeType(Type type, int maxDepth = 1);

    }
}