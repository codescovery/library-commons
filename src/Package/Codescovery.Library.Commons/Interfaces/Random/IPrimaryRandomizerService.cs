using Codescovery.Library.Commons.Extensions;
using System;
using Codescovery.Library.Commons.Entities.Options.Random;

namespace Codescovery.Library.Commons.Interfaces.Random
{
    public interface IPrimaryRandomizerService : IRandomService
    {
        int GetRandomInt(System.Random randomIstance = null);
        int? GetRandomNullableInt(System.Random randomIstance = null);
        double GetRandomDouble(System.Random randomIstance = null);
        double? GetRandomNullableDouble(System.Random randomIstance = null);
        float GetRandomFloat(System.Random randomIstance = null);

        float? GetRandomNullableFloat(System.Random randomIstance = null);
        decimal GetRandomDecimal(System.Random randomIstance = null);
        decimal? GetRandomNullableDecimal(System.Random randomIstance = null);
        long GetRandomLong(System.Random randomIstance = null);
        long? GetRandomNullableLong(System.Random randomIstance = null);
        bool GetRandomBoolean(System.Random randomIstance = null);
        bool? GetRandomNullableBoolean(System.Random randomIstance = null);
        DateTime GetRandomDatetime(int minValue = -365, int maxValue = 365, System.Random randomIstance = null);

        DateTime? GetRandomNullableDatetime(int minValue = -365, int maxValue = 365,
           System.Random randomIstance = null);

        string GetRandomString(
           RandomStringOptions options = null
       );

        string GetRandomNullableString(
           RandomStringOptions options = null, System.Random randomIstance = null
       );

        Guid GetRandomGuid();
        Guid GetRandomGuidOrEmptyGuid(System.Random randomIstance = null);
        Guid? GetRandomNullableGuidOrEmptyGuid(System.Random randomIstance = null);
        object GetRandomEnum(Type enumType, System.Random randomIstance = null);
        object GetRandomNullableEnum(Type enumType, System.Random randomIstance = null);
    }
}