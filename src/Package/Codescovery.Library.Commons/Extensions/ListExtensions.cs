using System;
using System.Collections.Generic;
using System.Text;

namespace Codescovery.Library.Commons.Extensions
{
    public static class ListExtensions
    {
        public static List<T> AsList<T>(this T source)
        {
            return source.IsNullOrDefault() ? new List<T>() : new List<T> { source };
        }
        public static IList<T> AsIList<T>(this T source)
        {
            return source.AsList();
        }

        public static IReadOnlyList<T> AsIReadOnlyList<T>(this T source)
        {
            return source.AsList();
        }
    }
}
