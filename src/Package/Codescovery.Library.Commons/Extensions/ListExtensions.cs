using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codescovery.Library.Commons.Extensions
{
    public static class ListExtensions
    {
        public static List<T> AsList<T>(this T? source)
        {
            return source.IsNullOrDefault() ? new List<T>() : new List<T> { source! };
        }
        public static IList<T> AsIList<T>(this T? source)
        {
            return source.AsList();
        }

        public static IReadOnlyList<T> AsIReadOnlyList<T>(this T? source)
        {
            return source.AsList();
        }
        public static bool ValueIn<T>(this IEnumerable<string>? source, string? value, StringComparison stringComparison =StringComparison.InvariantCultureIgnoreCase)
        {
            if (source.IsNullOrDefault() || value.IsNullOrDefault())
                return false;
            

            return source!.Any(x => x.Equals(value, stringComparison));
        }
    }
}
