using System;
using System.Diagnostics;

namespace Codescovery.Library.Commons.Extensions
{
    public static class EnumExtensions
    {

        public static int? ToNullableInt(this double? value)
        {
            return (int?)value;
        }

        public static int ToInt(this Enum enumValue, int defaultValue = default)
        {
            var result = enumValue.ToNullableInt(defaultValue);
            return result.IsNullOrDefault() ? defaultValue : result.Value;
        }
        public static int? ToNullableInt(this Enum enumValue, int? defaultValue = null)
        {
            if (enumValue.IsNullOrDefault())
                return defaultValue;
            try
            {
                return Convert.ToInt32(enumValue);
            }
            catch
            {

                return defaultValue;
            }
        }

    }
}