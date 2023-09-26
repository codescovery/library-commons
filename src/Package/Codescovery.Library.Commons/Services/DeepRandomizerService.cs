using System.Collections.Generic;
using System;
using Codescovery.Library.Commons.Builders;
using Codescovery.Library.Commons.Entities.Options.Random;
using Codescovery.Library.Commons.Interfaces.Mock;
using Codescovery.Library.Commons.Interfaces.Random;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Collections;
using Codescovery.Library.Commons.Extensions;
using Codescovery.Library.Commons.Interfaces;

namespace Codescovery.Library.Commons.Services
{
    internal class DeepRandomizerService : IDeepRandomizerService
    {
        private readonly Random _random;
        private readonly IRandomizerService _randomizerService;
        private readonly RandomStringOptions _randomStringOptions;
        private readonly IPrimaryRandomizerService _primaryRandomizerService;
        private readonly IMockedTypeGeneratorService _mockedTypeGeneratorService;



        public DeepRandomizerService(Random? random = null,
            IMockedTypeGeneratorService? mockedTypeGeneratorService = null,
            IRandomizerService? randomizerService = null,
            IPrimaryRandomizerService? primaryRandomizerService = null,
            RandomStringOptions? randomStringOptions = null
            )
        {


            _random = random ?? new Random();
            _randomStringOptions = randomStringOptions ?? new RandomStringOptions();
            _mockedTypeGeneratorService = mockedTypeGeneratorService ?? MockedTypeGeneratorServiceBuilder.BuildDefault();
            _primaryRandomizerService = primaryRandomizerService ?? PrimaryRandomizerServiceBuilder.BuildDefault(_random);
            _randomizerService = randomizerService ?? RandomizerServiceBuilder.BuildDefault(_random, _primaryRandomizerService);
        }

        public object? Randomize(Type type, int maxDepth = 1)
        {
            var method = typeof(IDeepRandomizerService).GetMethods()
                .Where(m => m.Name == nameof(IDeepRandomizerService.Randomize))
                .FirstOrDefault(m => m.IsGenericMethod);

            if (method == null) return null;

            var genericMethod = method.MakeGenericMethod(type);
            var result = genericMethod.Invoke(this, new object[] { maxDepth });
            return result;
        }
        public T? Randomize<T>(int maxDepth = 1)
        {
            var type = typeof(T);

            if (type.IsPrimitiveType())
                return (T)RandomizeType(type)!;
            if (maxDepth <= 0) return default;

            if (type.IsArray)
                return HandleArray<T>(type);


            if (type.IsGenericType)
                if (HandleGenericType(type, out T? resultList, maxDepth)) return resultList;


            var obj = Activator.CreateInstance<T>();
            if (obj.IsObject())
                PropertySetter(type, obj, maxDepth);
            else
                AddValuesToEnumerable(obj, maxDepth - 1);


            return obj;
        }


        public T HandleArray<T>(Type? type, int maxDepth = 1)
        {
            var elementType = type?.GetElementType();
            var array = Array.CreateInstance(elementType ?? throw new NullReferenceException(nameof(type)), _random.Next(1, maxDepth));
            for (var i = 0; i < array.Length; i++)
                array.SetValue(RandomizeType(elementType, maxDepth), i);


            return (T)(object)array;
        }

        public bool HandleGenericType<T>(Type? type, out T? resultList, int maxDepth = 1)
        {
            resultList = default;
            var genericTypeDefinition = type?.GetGenericTypeDefinition();
            if (genericTypeDefinition != typeof(List<>)) return false;
            var elementType = type?.GetGenericArguments()[0];
            if (elementType == null) return true;
            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType))!;
            if (maxDepth > 0)
                for (var i = 1; i < maxDepth; i++)
                    list.Add(Randomize(elementType, maxDepth));


            resultList = (T)list;

            return true;

        }

        public void AddValuesToEnumerable<T>(T obj, int maxDepth = 1)
        {
            var count = _random.Next(1, 4);
            var addMethod = obj?.GetType().GetMethod("Add");
            for (var i = 0; i < count; i++) HandleAdd(obj, addMethod, maxDepth);
        }

        public void HandleAdd<T>(T obj, MethodInfo? addMethod=null, int maxDepth = 1)
        {
            if (addMethod == null) return;
            addMethod.Invoke(obj, new[] { RandomizeType(obj?.GetType().GetGenericArguments()[0], maxDepth) });
        }



        public void PropertySetter(Type? type, object? obj, int maxDepth = 1)
        {
            var properties = type?.GetProperties();
            if (properties == null) return;
            foreach (var property in properties)
            {
                if (!property.CanWrite)
                    continue;


                property.SetValue(obj, Randomize(property.PropertyType, maxDepth - 1));
            }
        }

        public object? RandomizeType(Type? type, int maxDepth = 1)
        {
            if (type is { IsInterface: false }) return _randomizerService.RandomizeValueType(type, _random, _randomStringOptions);
            var mocked = _mockedTypeGeneratorService.CreateMockedObject(type);
            PropertySetter(mocked?.GetType(), mocked, maxDepth);
            return mocked;
        }

    }
}