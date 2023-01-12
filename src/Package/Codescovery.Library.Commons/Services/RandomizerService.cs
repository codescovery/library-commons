using System;
using Codescovery.Library.Commons.Entities.Options.Random;
using Codescovery.Library.Commons.Interfaces.Random;

namespace Codescovery.Library.Commons.Services
{
    internal class RandomizerService:IRandomizerService
    {
        private readonly IPrimaryRandomizerService _primaryRandomizerService;
        public Random Random { get; }
        public RandomizerService(Random random = null, IPrimaryRandomizerService primaryRandomizerService = null)
        {
            Random = random ?? new Random();
            _primaryRandomizerService = primaryRandomizerService ?? new PrimaryRandomizerService(Random);
        }

        
        public  object RandomizeValueType(Type type, Random randomInstance = null, RandomStringOptions randomStringOptions = null)
        {
            var random = randomInstance ?? new Random();

            if (type == typeof(int))
                return _primaryRandomizerService.GetRandomInt(random);
            if (type == typeof(int?))
                return _primaryRandomizerService.GetRandomNullableInt(random);

            if (type == typeof(double))
                return _primaryRandomizerService.GetRandomDouble(random);
            if (type == typeof(double?))
                return _primaryRandomizerService.GetRandomNullableDouble(random);

            if (type == typeof(float))
                return _primaryRandomizerService.GetRandomFloat(random);
            if (type == typeof(float?))
                return _primaryRandomizerService.GetRandomNullableFloat(random);

            if (type == typeof(decimal))
                return _primaryRandomizerService.GetRandomDecimal(random);
            if (type == typeof(decimal?))
                return _primaryRandomizerService.GetRandomNullableDecimal(random);

            if (type == typeof(long))
                return _primaryRandomizerService.GetRandomLong(random);
            if (type == typeof(long?))
                return _primaryRandomizerService.GetRandomNullableLong(random);

            if (type == typeof(bool))
                return _primaryRandomizerService.GetRandomBoolean(random);
            if (type == typeof(bool?))
                return _primaryRandomizerService.GetRandomNullableBoolean(random);

            if (type == typeof(string))
                return _primaryRandomizerService.GetRandomNullableString(randomStringOptions);


            if (type == typeof(DateTime))
                return _primaryRandomizerService.GetRandomDatetime(-365, 365, random);
            if (type == typeof(DateTime?))
                return _primaryRandomizerService.GetRandomNullableDatetime(-365, 365, random);

            if (type == typeof(Guid))
                return _primaryRandomizerService.GetRandomGuidOrEmptyGuid(random);
            if (type == typeof(Guid?))
                return _primaryRandomizerService.GetRandomNullableGuidOrEmptyGuid(random);

            if (type.IsEnum)
                return _primaryRandomizerService.GetRandomNullableEnum(type,random);

            return null;
        }

    }
}