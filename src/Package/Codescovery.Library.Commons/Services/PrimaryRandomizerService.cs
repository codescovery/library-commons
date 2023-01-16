using Codescovery.Library.Commons.Extensions;
using System;
using Codescovery.Library.Commons.Entities.Options.Random;
using Codescovery.Library.Commons.Interfaces.Random;
namespace Codescovery.Library.Commons.Services
{
    internal class PrimaryRandomizerService:IPrimaryRandomizerService
    {
        public Random Random { get; }
        public PrimaryRandomizerService(Random random = null)
        {
            Random = random ?? new Random();
        }

        public  int GetRandomInt(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            return random.Next();
        }
        public  int? GetRandomNullableInt(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return null;
            return GetRandomInt(random);
        }
        public  double GetRandomDouble(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            return random.NextDouble();
        }
        public  double? GetRandomNullableDouble(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return null;
            return GetRandomDouble(random);
        }
        public  float GetRandomFloat(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            return (float)random.NextDouble();
        }

        public  float? GetRandomNullableFloat(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return null;
            return GetRandomFloat(random);
        }
        public  decimal GetRandomDecimal(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            return (decimal)random.NextDouble();
        }
        public  decimal? GetRandomNullableDecimal(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return null;
            return GetRandomDecimal(random);
        }
        public  long GetRandomLong(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            return random.Next();
        }
        public  long? GetRandomNullableLong(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return null;
            return GetRandomLong(random);
        }
        public  bool GetRandomBoolean(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            return random.Next(0, 2) == 0;
        }
        public  bool? GetRandomNullableBoolean(Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return null;
            return GetRandomBoolean(random);
        }
        public  DateTime GetRandomDatetime(int minValue = -365, int maxValue = 365, Random randomIstance = null)
        {
            var random = randomIstance ?? Random;

            return DateTime.Now.AddDays(random.Next(minValue, maxValue));
        }
        public  DateTime? GetRandomNullableDatetime(int minValue = -365, int maxValue = 365, Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return null;
            return GetRandomDatetime(minValue, maxValue, random);
        }
        public  string GetRandomString(
            RandomStringOptions options = null
        )
        {
            var persistedStringOptions = options ?? new RandomStringOptions();
            var randomString = $"RandomString:{Guid.NewGuid()}";

            if (persistedStringOptions.RemoveTabs)
                randomString = randomString.Replace(persistedStringOptions.TabValue, string.Empty);
            if (persistedStringOptions.RemoveNewLine)
                randomString = randomString.Replace(persistedStringOptions.NewLineValue, string.Empty);
            if (persistedStringOptions.RemoveCarriageReturn)
                randomString = randomString.Replace(persistedStringOptions.CarriageReturnValue, string.Empty);

            if (!persistedStringOptions.RemoveSpecialChars) return randomString.GetSubstring(length: persistedStringOptions.MaxLenght);

            var regex = persistedStringOptions.SpecialCharsRegex.ToRegex(persistedStringOptions.RegexOptions);
            return !regex.IsValid ? randomString.GetSubstring(length: persistedStringOptions.MaxLenght) : regex.Regex.Replace(randomString, persistedStringOptions.SpecialCharsReplacementValue);
        }

        public  string GetRandomNullableString(
            RandomStringOptions options = null, Random randomIstance = null
        )
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return null;
            return GetRandomString(options);
        }

        public  Guid GetRandomGuid()
        {
            return Guid.NewGuid();
        }
        public  Guid GetRandomGuidOrEmptyGuid(Random randomIstance = null)
        {
            var random = randomIstance ??  Random;
            if (GetRandomBoolean(random))
                return Guid.Empty;
            return GetRandomGuid();
        }
        public  Guid? GetRandomNullableGuidOrEmptyGuid(Random randomIstance = null)
        {
            var random = randomIstance ??  Random;
            if (GetRandomBoolean(random))
                return Guid.Empty;
            return GetRandomGuidOrEmptyGuid(random);
        }
        public object GetRandomEnum(Type enumType, Random randomIstance = null)
        
        {
            var random = randomIstance ?? Random;
            var enumValues = Enum.GetValues(enumType);
            return enumValues.GetValue(random.Next(enumValues.Length));
        }
        public object GetRandomNullableEnum(Type enumType, Random randomIstance = null)
        {
            var random = randomIstance ?? Random;
            if (GetRandomBoolean(random))
                return  Activator.CreateInstance(enumType);
            return GetRandomEnum(enumType, random);
        }

    }
}