using System;

namespace Codescovery.Library.Commons.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsPrimitiveType(this Type? type)
        {
            if (type == null) return false;
            return type.IsValueType || type == typeof(string) || type.IsEnum;
        }
        public static  bool IsObject<T>(this T obj)
        {
            return !(obj is System.Collections.IEnumerable) || obj is string;
        }
    }
}