using System.Collections.Generic;
using System;
using Codescovery.Library.Commons.Builders;
using Codescovery.Library.Commons.Entities.Options.Random;
using Codescovery.Library.Commons.Interfaces;
using Codescovery.Library.Commons.Interfaces.Mock;
using Codescovery.Library.Commons.Interfaces.Random;
using System.Data;
using System.Reflection;

namespace Codescovery.Library.Commons.Services
{
    internal class DeepRandomizerService : IDeepRandomizerService
    {
        private readonly Random _random;
        private readonly IRandomizerService _randomizerService;
        private readonly RandomStringOptions _randomStringOptions;
        private readonly IPrimaryRandomizerService _primaryRandomizerService;
        private readonly IMockedTypeGeneratorService _mockedTypeGeneratorService;



        public DeepRandomizerService(Random random = null,
            IMockedTypeGeneratorService mockedTypeGeneratorService = null,
            IRandomizerService randomizerService = null,
            IPrimaryRandomizerService primaryRandomizerService = null,
            RandomStringOptions randomStringOptions = null
            )
        {


            _random = random ?? new Random();
            _randomStringOptions = randomStringOptions ?? new RandomStringOptions();
            _mockedTypeGeneratorService = mockedTypeGeneratorService ?? MockedTypeGeneratorServiceBuilder.BuildDefault();
            _primaryRandomizerService = primaryRandomizerService ?? PrimaryRandomizerServiceBuilder.BuildDefault(_random);
            _randomizerService = randomizerService ?? RandomizerServiceBuilder.BuildDefault(_random, _primaryRandomizerService);
        }

        public object Randomizer(Type type)
        {
            var method = typeof(IDeepRandomizerService).GetMethod(nameof(IDeepRandomizerService.Randomize));
            if (method == null) return null;

            var genericMethod = method.MakeGenericMethod(type);
            var result = genericMethod.Invoke(this, null);
            return result;
        }
        public T Randomize<T>()
        {
            var type = typeof(T);
            if (type.IsValueType || type == typeof(string))
                return HandleString<T>(type);
            if (type.IsEnum)
                return (T)RandomizeType(type);

            if (type.IsArray)
                return HandleArray<T>(type);


            if (type.IsGenericType)
                if (HandleGenericType(type, out T resultList)) return resultList;
            

            var obj = Activator.CreateInstance<T>();
            if (IsObject(obj))
                PropertySetter(type, obj);
            else
                AddValuesToEnumerable(obj);


            return obj;
        }

        private T HandleString<T>(Type type)
        {
            return (T)_randomizerService.RandomizeValueType(type, _random);
        }

        private T HandleArray<T>(Type type)
        {
            var elementType = type.GetElementType();
            var array = Array.CreateInstance(elementType, _random.Next(1, 4));
            for (var i = 0; i < array.Length; i++)
            {
                array.SetValue(RandomizeType(elementType), i);
            }

            return (T)(object)array;
        }

        private bool HandleGenericType<T>(Type type, out T resultList)
        {
            resultList = default;
            var genericTypeDefinition = type.GetGenericTypeDefinition();
            if (genericTypeDefinition != typeof(List<>)) return false;
            var elementType = type.GetGenericArguments()[0];
            var list = (IList<object>)Activator.CreateInstance(typeof(List<>).MakeGenericType(elementType));
            var count = _random.Next(1, 4);
            for (var i = 0; i < count; i++)
                
                list.Add(RandomizeType(elementType));

             
            resultList = (T)list;
            return true;

        }

        private void AddValuesToEnumerable<T>(T obj)
        {
            var count = _random.Next(1, 4);
            var addMethod = obj.GetType().GetMethod("Add");
            for (var i = 0; i < count; i++) HandleAdd(obj, addMethod);
        }

        private void HandleAdd<T>(T obj, MethodInfo addMethod)
        {
            if (addMethod != null)
                addMethod.Invoke(obj, new[] {RandomizeType(obj.GetType().GetGenericArguments()[0])});
        }

        private static bool IsObject<T>(T obj)
        {
            return !(obj is System.Collections.IEnumerable) || obj is string;
        }

        private void PropertySetter<TObjectType>(Type type, TObjectType obj)
        {
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (!property.CanWrite)
                    continue;
                

                property.SetValue(obj, Randomizer(property.PropertyType));
            }
        }

        private object RandomizeType(Type type)
        {
            if (!type.IsInterface) return _randomizerService.RandomizeValueType(type, _random, _randomStringOptions);
            var mocked = _mockedTypeGeneratorService.CreateMockedObject(type);
            PropertySetter(mocked.GetType(), mocked);
            return mocked;
        }

    }
}